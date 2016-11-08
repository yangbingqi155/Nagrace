using Magelia.WebStore.Contracts;
using Magelia.WebStore.Models.Parts;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Orchard.UI.Notify;
using System;

namespace Magelia.WebStore.Drivers
{
    public class SettingsPartDriver : ContentPartDriver<SettingsPart>
    {
        private INotifier _notifier;
        private Localizer _localizer;
        private IOrchardServices _orcharServices;
        private IWebStoreServices _webStoreServices;
        private ICacheManagerServices _cacheManagerServices;

        protected override String Prefix
        {
            get
            {
                return "Magelia_WebStore_Settings";
            }
        }

        private void EnsureCurrentUser()
        {
            this._webStoreServices.EnsureUser(this._orcharServices.WorkContext.CurrentUser);
        }

        private void ClearCache()
        {
            this._cacheManagerServices.Clear();
        }

        protected override DriverResult Editor(SettingsPart part, dynamic shapeHelper)
        {
            if (part.CacheExpiration == 0)
            {
                part.CacheExpiration = 24;
            }

            return this.ContentShape(
                "Parts_Settings_Edit",
                () => shapeHelper.EditorTemplate(
                    Model: part,
                    Prefix: this.Prefix,
                    TemplateName: "Parts/Settings"
                )
            )
            .OnGroup("WebStoreSettings");
        }

        protected override DriverResult Editor(SettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            if (updater.TryUpdateModel(part, this.Prefix, null, null))
            {
                this.ClearCache();
                this.EnsureCurrentUser();
            }

            return this.Editor(part, shapeHelper);
        }

        public SettingsPartDriver(INotifier notifier, IWebStoreServices webStoreServices, IOrchardServices orcharServices, ICacheManagerServices cacheManagerServices)
        {
            this._notifier = notifier;
            this._orcharServices = orcharServices;
            this._localizer = NullLocalizer.Instance;
            this._webStoreServices = webStoreServices;
            this._cacheManagerServices = cacheManagerServices;
        }
    }
}