using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Advertise.Services;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Settings;
using Orchard.UI.Navigation;
using Orchard.Advertise.Models;
using Orchard.Core.Feeds;
using Orchard.Mvc;

namespace Orchard.Advertise.Controllers
{
    public class AdvertiseController : Controller, IUpdateModel {
        private readonly IOrchardServices _services;
        private readonly IAdvertiseService _advertiseService;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        private readonly ISiteService _siteService;

        public AdvertiseController(
            IOrchardServices services,
            IAdvertiseService advertiseService,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            ISiteService siteService,
            IShapeFactory shapeFactory, IOrchardServices orchardServices) {
            Services = services;
            _advertiseService = advertiseService;
            _contentManager = contentManager;
            _transactionManager = transactionManager;
            _siteService = siteService;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
            _services = orchardServices;
        }

        dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public IOrchardServices Services { get; set; }


        public ActionResult Item(int advertiseId, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);

            var advertisePart = _advertiseService.Get(advertiseId, VersionOptions.Published).As<AdvertisePart>();
            if (advertisePart == null)
                return HttpNotFound();

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.ViewContent, advertisePart, T("Cannot view content"))) {
                return new HttpUnauthorizedResult();
            }
            
            dynamic advertise = _services.ContentManager.BuildDisplay(advertisePart);
            
            return new ShapeResult(this, advertise);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }


        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }
    }
}