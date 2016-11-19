using System.Linq;
using System.Web.Mvc;
using Orchard.Advertise.Extensions;
using Orchard.Advertise.Models;
using Orchard.Advertise.Services;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.UI.Admin;
using Orchard.UI.Navigation;
using Orchard.UI.Notify;
using Orchard.Settings;

namespace Orchard.Advertise.Controllers {

    [ValidateInput(false), Admin]
    public class AdvertiseAdminController : Controller, IUpdateModel {
        private readonly IAdvertiseService _advertiseService;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        private readonly ISiteService _siteService;

        public AdvertiseAdminController(
            IOrchardServices services,
            IAdvertiseService advertiseService,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            ISiteService siteService,
            IShapeFactory shapeFactory) {
            Services = services;
            _advertiseService = advertiseService;
            _contentManager = contentManager;
            _transactionManager = transactionManager;
            _siteService = siteService;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }

        dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public IOrchardServices Services { get; set; }

        public ActionResult Create() {
            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, T("Not allowed to create advertises")))
                return new HttpUnauthorizedResult();

            AdvertisePart advertise = Services.ContentManager.New<AdvertisePart>("Advertise");
            if (advertise == null)
                return HttpNotFound();

            var model = Services.ContentManager.BuildEditor(advertise);
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreatePOST() {
            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, T("Couldn't create advertise")))
                return new HttpUnauthorizedResult();

            var advertise = Services.ContentManager.New<AdvertisePart>("Advertise");

            _contentManager.Create(advertise, VersionOptions.Draft);
            var model = _contentManager.UpdateEditor(advertise, this);

            if (!ModelState.IsValid) {
                _transactionManager.Cancel();
                return View(model);
            }

            _contentManager.Publish(advertise.ContentItem);
            return Redirect(Url.AdvertiseForAdmin(advertise));
        }

        public ActionResult Edit(int advertiseId) {
            var advertise = _advertiseService.Get(advertiseId, VersionOptions.Latest);

            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, advertise, T("Not allowed to edit advertise")))
                return new HttpUnauthorizedResult();

            if (advertise == null)
                return HttpNotFound();

            var model = Services.ContentManager.BuildEditor(advertise);
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        [FormValueRequired("submit.Delete")]
        public ActionResult EditDeletePOST(int advertiseId) {
            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, T("Couldn't delete advertise")))
                return new HttpUnauthorizedResult();

            var advertise = _advertiseService.Get(advertiseId, VersionOptions.DraftRequired);
            if (advertise == null)
                return HttpNotFound();
            _advertiseService.Delete(advertise);

            Services.Notifier.Success(T("Advertise deleted"));

            return Redirect(Url.AdvertisesForAdmin());
        }


        [HttpPost, ActionName("Edit")]
        [FormValueRequired("submit.Save")]
        public ActionResult EditPOST(int advertiseId) {
            var advertise = _advertiseService.Get(advertiseId, VersionOptions.DraftRequired);

            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, advertise, T("Couldn't edit advertise")))
                return new HttpUnauthorizedResult();

            if (advertise == null)
                return HttpNotFound();

            var model = Services.ContentManager.UpdateEditor(advertise, this);
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
                return View(model);
            }

            _contentManager.Publish(advertise);
            Services.Notifier.Success(T("Advertise information updated"));

            return Redirect(Url.AdvertisesForAdmin());
        }

        [HttpPost]
        public ActionResult Remove(int advertiseId) {
            if (!Services.Authorizer.Authorize(Permissions.ManageAdvertise, T("Couldn't delete advertise")))
                return new HttpUnauthorizedResult();

            var advertise = _advertiseService.Get(advertiseId, VersionOptions.Latest);

            if (advertise == null)
                return HttpNotFound();

            _advertiseService.Delete(advertise);

            Services.Notifier.Success(T("Advertise was successfully deleted"));
            return Redirect(Url.AdvertisesForAdmin());
        }

        public ActionResult List() {
            var list = Services.New.List();
            list.AddRange(_advertiseService.Get(VersionOptions.Latest)
                .Where(x => Services.Authorizer.Authorize(Permissions.ManageOwnAdvertise, x))
                .Select(b => {
                            var advertise = Services.ContentManager.BuildDisplay(b, "SummaryAdmin");
                            return advertise;
                        }));

            var viewModel = Services.New.ViewModel()
                .ContentItems(list);
            return View(viewModel);
        }

        public ActionResult Item(int advertiseId, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            var advertise = _advertiseService.Get(advertiseId, VersionOptions.Latest);

            if (advertise == null)
                return HttpNotFound();
            
            var model = Services.ContentManager.BuildDisplay(advertise);
            return View(model);
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}