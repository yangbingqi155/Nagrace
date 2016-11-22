using System.Linq;
using System.Web.Mvc;
using Orchard.Product.Extensions;
using Orchard.Product.Models;
using Orchard.Product.Services;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.UI.Admin;
using Orchard.UI.Navigation;
using Orchard.UI.Notify;
using Orchard.Settings;

namespace Orchard.Product.Controllers {

    [ValidateInput(false), Admin]
    public class ProductAdminController : Controller, IUpdateModel {
        private readonly IProductService _productService;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        private readonly ISiteService _siteService;

        public ProductAdminController(
            IOrchardServices services,
            IProductService productService,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            ISiteService siteService,
            IShapeFactory shapeFactory) {
            Services = services;
            _productService = productService;
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
            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, T("Not allowed to create products")))
                return new HttpUnauthorizedResult();

            ProductPart product = Services.ContentManager.New<ProductPart>("Product");
            if (product == null)
                return HttpNotFound();

            var model = Services.ContentManager.BuildEditor(product);
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreatePOST() {
            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, T("Couldn't create product")))
                return new HttpUnauthorizedResult();

            var product = Services.ContentManager.New<ProductPart>("Product");

            _contentManager.Create(product, VersionOptions.Draft);
            var model = _contentManager.UpdateEditor(product, this);

            if (!ModelState.IsValid) {
                _transactionManager.Cancel();
                return View(model);
            }

            _contentManager.Publish(product.ContentItem);
            return Redirect(Url.ProductForAdmin(product));
        }

        public ActionResult Edit(int productId) {
            var product = _productService.Get(productId, VersionOptions.Latest);

            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, product, T("Not allowed to edit product")))
                return new HttpUnauthorizedResult();

            if (product == null)
                return HttpNotFound();

            var model = Services.ContentManager.BuildEditor(product);
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        [FormValueRequired("submit.Delete")]
        public ActionResult EditDeletePOST(int productId) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, T("Couldn't delete product")))
                return new HttpUnauthorizedResult();

            var product = _productService.Get(productId, VersionOptions.DraftRequired);
            if (product == null)
                return HttpNotFound();
            _productService.Delete(product);

            Services.Notifier.Success(T("Product deleted"));

            return Redirect(Url.ProductsForAdmin());
        }


        [HttpPost, ActionName("Edit")]
        [FormValueRequired("submit.Save")]
        public ActionResult EditPOST(int productId) {
            var product = _productService.Get(productId, VersionOptions.DraftRequired);

            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, product, T("Couldn't edit product")))
                return new HttpUnauthorizedResult();

            if (product == null)
                return HttpNotFound();

            var model = Services.ContentManager.UpdateEditor(product, this);
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
                return View(model);
            }

            _contentManager.Publish(product);
            Services.Notifier.Success(T("Product information updated"));

            return Redirect(Url.ProductsForAdmin());
        }

        [HttpPost]
        public ActionResult Remove(int productId) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProduct, T("Couldn't delete product")))
                return new HttpUnauthorizedResult();

            var product = _productService.Get(productId, VersionOptions.Latest);

            if (product == null)
                return HttpNotFound();

            _productService.Delete(product);

            Services.Notifier.Success(T("Product was successfully deleted"));
            return Redirect(Url.ProductsForAdmin());
        }

        public ActionResult List() {
            var list = Services.New.List();
            list.AddRange(_productService.Get(VersionOptions.Latest)
                .Where(x => Services.Authorizer.Authorize(Permissions.ManageOwnProduct, x))
                .Select(b => {
                            var product = Services.ContentManager.BuildDisplay(b, "SummaryAdmin");
                            return product;
                        }));

            var viewModel = Services.New.ViewModel()
                .ContentItems(list);
            return View(viewModel);
        }

        public ActionResult Item(int productId, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            var product = _productService.Get(productId, VersionOptions.Latest);

            if (product == null)
                return HttpNotFound();
            
            var model = Services.ContentManager.BuildDisplay(product);
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