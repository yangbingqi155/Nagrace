using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Alias;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.LearnOrchard.FeatureProduct.Models;
using Orchard.LearnOrchard.FeatureProduct.Services;

namespace Orchard.LearnOrchard.FeatureProduct.Drivers {
    public class FeaturedProductDriver : ContentPartDriver<FeaturedProductPart> {
        private readonly IFeaturedProductService _featuredProductService;
        public FeaturedProductDriver(IFeaturedProductService featuredProductService) {
            _featuredProductService = featuredProductService;
        }

        protected override DriverResult Display(FeaturedProductPart part,
            string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
                return shapeHelper.Parts_FeaturedProduct(IsOnFeaturedProductPage: _featuredProductService.IsOnFeaturedProductPage());
                });
        }

        protected override DriverResult Editor(FeaturedProductPart part,
  dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct_Edit",
              () => shapeHelper.EditorTemplate(
                TemplateName: "Parts/FeaturedProduct",
                Model: part,
                Prefix: Prefix));
        }

        protected override DriverResult Editor(FeaturedProductPart part,
  IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

    }
}