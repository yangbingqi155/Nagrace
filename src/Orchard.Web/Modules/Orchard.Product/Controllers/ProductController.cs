using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Product.Services;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Settings;
using Orchard.UI.Navigation;
using Orchard.Product.Models;
using Orchard.Core.Feeds;
using Orchard.Mvc;

namespace Orchard.Product.Controllers
{
    public class ProductController : Controller, IUpdateModel {
        private readonly IOrchardServices _services;
        private readonly IProductService _productService;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        private readonly ISiteService _siteService;

        public ProductController(
            IOrchardServices services,
            IProductService productService,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            ISiteService siteService,
            IShapeFactory shapeFactory, IOrchardServices orchardServices) {
            Services = services;
            _productService = productService;
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


        public ActionResult Item(int productId, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);

            var productPart = _productService.Get(productId, VersionOptions.Published).As<ProductPart>();
            if (productPart == null)
                return HttpNotFound();

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.ViewContent, productPart, T("Cannot view content"))) {
                return new HttpUnauthorizedResult();
            }
            
            dynamic product = _services.ContentManager.BuildDisplay(productPart);
            
            return new ShapeResult(this, product);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }


        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }
    }
}