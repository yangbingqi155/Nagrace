using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Orchard.LearnOrchard.FeatureProduct.Models {
    public class FeaturedProductPart:ContentPart<FeaturedProductPartRecord>{
        [DisplayName("Is the featured product on sale?")]
        public bool IsOnSale {
            get { return Retrieve(r => r.IsOnSale); }
            set { Store(r => r.IsOnSale,value); }
        }
    }
}