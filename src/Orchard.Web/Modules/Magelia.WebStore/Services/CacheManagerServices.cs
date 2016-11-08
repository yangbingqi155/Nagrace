using Magelia.WebStore.Contracts;
using Magelia.WebStore.Models.Parts;
using Orchard;
using Orchard.ContentManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;

namespace Magelia.WebStore.Services
{
    public class CacheManagerServices : ICacheManagerServices
    {
        private const String KeySeparator = "-";
        private const String MageliaCachePrefix = "Magelia";

        private Lazy<SettingsPart> _settings;
        private IOrchardServices _orchardServices;

        private SettingsPart GetSettings()
        {
            return this._orchardServices.WorkContext.CurrentSite.As<SettingsPart>();
        }

        private String GenerateKey(params Object[] keys)
        {
            keys = keys.Where(k => k != null)
                       .ToArray();

            if (keys.Length == 0)
            {
                throw new ArgumentException("One key at least must be specified", "keys");
            }

            String key = String.Join(CacheManagerServices.KeySeparator, new[] { CacheManagerServices.MageliaCachePrefix }.Concat(keys));

            return key;
        }

        private IEnumerable<String> GetMageliaCacheKeys()
        {
            IDictionaryEnumerator enumerator = this._orchardServices.WorkContext.HttpContext.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                String key = enumerator.Entry.Key as String;

                if (!String.IsNullOrEmpty(key) && key.StartsWith(CacheManagerServices.MageliaCachePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    yield return key;
                }
            }
        }

        public CacheManagerServices(IOrchardServices orchardServices)
        {
            this._orchardServices = orchardServices;
            this._settings = new Lazy<SettingsPart>(this.GetSettings);
        }

        public void Clear()
        {
            String[] mageliaCacheKeys = this.GetMageliaCacheKeys().ToArray();

            foreach (String mageliaCacheKey in mageliaCacheKeys)
            {
                this._orchardServices.WorkContext.HttpContext.Cache.Remove(mageliaCacheKey);
            }
        }

        public T GetOrAdd<T>(Func<T> create, params Object[] keys)
        {
            String key = this.GenerateKey(keys);
            Object value = this._orchardServices.WorkContext.HttpContext.Cache.Get(key);

            if (value == null)
            {
                value = create();

                if (value != null)
                {
                    this._orchardServices.WorkContext.HttpContext.Cache.Add(
                        key,
                        value,
                        null,
                        DateTime.Now.AddHours(this._settings.Value.CacheExpiration),
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Normal,
                        null
                    );
                }
            }

            return (T)value;
        }
    }
}