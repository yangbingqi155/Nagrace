using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Orchard.Product.Models;
using Orchard.ContentManagement;

namespace Orchard.Product.Drivers {
    public class ProductPartDriver : ContentPartDriver<ProductPart> {

        IContentManager _contentManager;
        
        public ProductPartDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Product", () => {
                
                return shapeHelper.Parts_Product(
                    List: null);

            });
        }

        protected override DriverResult Editor(ProductPart part, dynamic shapeHelper) {
 
            return ContentShape("Parts_Product_Edit", () =>
                 shapeHelper.EditorTemplate(TemplateName: "Parts.Product", Model: part, Prefix: Prefix)
            );
        }

        protected override DriverResult Editor(ProductPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);

        }
    }
}