using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Orchard.Advertise.Models;
using Orchard.ContentManagement;

namespace Orchard.Advertise.Drivers {
    public class AdvertisePartDriver :ContentPartDriver<AdvertisePart>{

        IContentManager _contentManager;
        
        public AdvertisePartDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        protected override DriverResult Display(AdvertisePart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Advertise", () => {
                
                return shapeHelper.Parts_Advertise(
                    List: null);

            });
        }

        protected override DriverResult Editor(AdvertisePart part, dynamic shapeHelper) {
 
            return ContentShape("Parts_Advertise_Edit", () =>
                 shapeHelper.EditorTemplate(TemplateName: "Parts.Advertise", Model: part, Prefix: Prefix)
            );
        }

        protected override DriverResult Editor(AdvertisePart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);

        }
    }
}