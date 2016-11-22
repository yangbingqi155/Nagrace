using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;
using Orchard.Product.Services;

namespace Orchard.Product {
    public class AdminMenu:INavigationProvider {

        private readonly IProductService _productService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IWorkContextAccessor _workContextAccessor;

        public AdminMenu(IProductService productService, IAuthorizationService authorizationService, IWorkContextAccessor workContextAccessor) {
            _productService = productService;
            _authorizationService = authorizationService;
            _workContextAccessor = workContextAccessor;
        }

        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Product"), "1.5", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu) {
            var products = _productService.Get().Where(x => _authorizationService.TryCheckAccess(Permissions.ManageProduct, _workContextAccessor.GetContext().CurrentUser, x)).ToArray();
            var productCount = products.Count();
            var singleProduct = productCount == 1 ? products.ElementAt(0) : null;

            if (productCount > 0 && singleProduct == null) {
                menu.Add(T("Manage Products"), "3",
                         item => item.Action("List", "ProductAdmin", new { area = "Orchard.Product" }).Permission(Permissions.ManageProduct));
            }
            else if (singleProduct != null)
                menu.Add(T("Manage Product"), "1.0",
                    item => item.Action("Item", "ProductAdmin", new { area = "Orchard.Product", productId = singleProduct.Id }).Permission(Permissions.ManageOwnProduct));

            menu.Add(T("New Product"), "1.2",
                    item =>
                    item.Action("Create", "ProductAdmin", new { area = "Orchard.Product" }).Permission(Permissions.ManageProduct));



        }
    }
}