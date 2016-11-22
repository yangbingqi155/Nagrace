using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Product.Models;
using Orchard.Data;
using System.Web.Routing;

namespace Orchard.Product.Handlers {
    public class ProductPartHandler:ContentHandler {
        public ProductPartHandler(IRepository<ProductPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnGetDisplayShape<ProductPart>((context, product) => {
            });
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var product = context.ContentItem.As<ProductPart>();

            if (product == null)
                return;

            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Product"},
                {"Controller", "Product"},
                {"Action", "Item"},
                {"productId", context.ContentItem.Id}
            };
            context.Metadata.CreateRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Product"},
                {"Controller", "ProductAdmin"},
                {"Action", "Create"}
            };
            context.Metadata.EditorRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Product"},
                {"Controller", "ProductAdmin"},
                {"Action", "Edit"},
                {"productId", context.ContentItem.Id}
            };
            context.Metadata.RemoveRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Product"},
                {"Controller", "ProductAdmin"},
                {"Action", "Remove"},
                {"productId", context.ContentItem.Id}
            };
            context.Metadata.AdminRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Product"},
                {"Controller", "ProductAdmin"},
                {"Action", "Item"},
                {"productId", context.ContentItem.Id}
            };
        }
    }
}