using System.Web;
using System.Web.Mvc;
using Orchard.Product.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Mvc.Extensions;

namespace Orchard.Product.Extensions {
    /// <summary>
    /// TODO: (PH:Autoroute) Many of these are or could be redundant (see controllers)
    /// </summary>
    public static class UrlHelperExtensions {
        public static string Products(this UrlHelper urlHelper) {
            return urlHelper.Action("List", "Product", new {area = "Orchard.Product" });
        }

        public static string ProductsForAdmin(this UrlHelper urlHelper) {
            return urlHelper.Action("List", "ProductAdmin", new {area = "Orchard.Product" });
        }

        public static string Product(this UrlHelper urlHelper, ProductPart productPart) {
            return urlHelper.Action("Item", "Product", new { productId = productPart.Id, area = "Orchard.Product" });
        }
        

        public static string ProductForAdmin(this UrlHelper urlHelper, ProductPart productPart) {
            return urlHelper.Action("Item", "ProductAdmin", new { productId = productPart.Id, area = "Orchard.Product" });
        }

        public static string ProductCreate(this UrlHelper urlHelper) {
            return urlHelper.Action("Create", "ProductAdmin", new { area = "Orchard.Product" });
        }

        public static string ProductEdit(this UrlHelper urlHelper, ProductPart productPart) {
            return urlHelper.Action("Edit", "ProducteAdmin", new { productId = productPart.Id, area = "Orchard.Product" });
        }

        public static string ProductRemove(this UrlHelper urlHelper, ProductPart productPart) {
            return urlHelper.Action("Remove", "ProductAdmin", new { productId = productPart.Id, area = "Orchard.Product" });
        }
    }
}