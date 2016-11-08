using Magelia.WebStore.Contracts;
using Orchard;
using System;
using System.Linq;

namespace Magelia.WebStore.Services
{
    public class SessionManagerServices : ISessionManagerServices
    {
        private const String KeySeparator = "-";
        private const String UserContextPrefix = "UserContext";
        private const String CommonContextPrefix = "CommonContext";
        private const String CommerceContextPrefix = "CommerceContext";

        private IOrchardServices _orchardServices;

        private String GenerateKey(params Object[] fragments)
        {
            return String.Join(SessionManagerServices.KeySeparator, fragments);
        }

        private T Get<T>(String key, Boolean create)
        {
            Boolean isNull = this._orchardServices.WorkContext.HttpContext.Session[key] == null;

            if (isNull && create)
            {
                this.Set<T>(key, Activator.CreateInstance<T>());
            }

            return !isNull || create ?
                        (T)this._orchardServices.WorkContext.HttpContext.Session[key] :
                        default(T);
        }

        private void Set<T>(String key, T value)
        {
            if (value == null)
            {
                this._orchardServices.WorkContext.HttpContext.Session.Remove(key);
            }
            else
            {
                this._orchardServices.WorkContext.HttpContext.Session[key] = value;
            }
        }

        private void Flush(String prefix)
        {
            this._orchardServices.WorkContext.HttpContext.Session.Keys.Cast<String>()
                                                                      .Where(k => k.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                                                                      .ToList()
                                                                      .ForEach(k => this._orchardServices.WorkContext.HttpContext.Session.Remove(k));
        }

        public SessionManagerServices(IOrchardServices orchardServices)
        {
            this._orchardServices = orchardServices;
        }

        public T GetFromCommerceContext<T>(String key, Int32 id)
            where T : new()
        {
            return this.Get<T>(this.GenerateKey(SessionManagerServices.CommerceContextPrefix, key, id), true);
        }

        public T GetFromUserContext<T>(String key, Int32 id)
            where T : new()
        {
            return this.Get<T>(this.GenerateKey(SessionManagerServices.UserContextPrefix, key, id), true);
        }

        public T GetFromCommonContext<T>(String key)
        {
            return this.Get<T>(this.GenerateKey(SessionManagerServices.CommonContextPrefix, key), false);
        }

        public void FlushCommerceContext()
        {
            this.Flush(SessionManagerServices.CommerceContextPrefix);
        }

        public void FlushUserContext()
        {
            this.Flush(SessionManagerServices.UserContextPrefix);
        }

        public void SetInCommonContext<T>(String key, T value)
        {
            this.Set<T>(this.GenerateKey(SessionManagerServices.CommonContextPrefix, key), value);
        }
    }
}