using Magelia.WebStore.Contracts;
using Orchard.Localization;
using Orchard.UI.Admin;
using System;
using System.ServiceModel;
using System.Web.Mvc;

namespace Magelia.WebStore.Controllers
{
    [Admin]
    public class SettingsController : Controller
    {
        private Localizer _localizer;
        private IWebStoreServices _webStoreServices;
        private ICacheManagerServices _cacheManagerServices;

        public SettingsController(IWebStoreServices webStoreServices, ICacheManagerServices cacheManagerServices)
        {
            this._localizer = NullLocalizer.Instance;
            this._webStoreServices = webStoreServices;
            this._cacheManagerServices = cacheManagerServices;
        }

        [HttpPost]
        public JsonResult Test(Guid storeId, String servicesPath)
        {
            String message = "Services successfuly tested";
            Exception exception = this._webStoreServices.UsingClient(storeId, servicesPath, c => c.StoreClient.GetContext(null));

            if (exception != null)
            {
                if (exception is ProtocolException)
                {
                    message = "Services couldn't be reached at the specified path";
                }
                else if (exception is UriFormatException)
                {
                    message = "Invalid service path";
                }
                else if (exception is FaultException)
                {
                    message = "Services are not responding with the specified store ID";
                }
                else
                {
                    message = "An error has occured during services connection, please check parameters and services connectivity";
                }
            }

            return this.Json(new { message = this._localizer(message).ToString() });
        }

        [HttpPost]
        public JsonResult ClearCache()
        {
            Boolean success;
            String message = null;

            try
            {
                this._cacheManagerServices.Clear();
                success = true;
            }
            catch (Exception exception)
            {
                success = false;
                message = exception.Message;
            }

            return this.Json(new { success = success, message = message });
        }
    }
}