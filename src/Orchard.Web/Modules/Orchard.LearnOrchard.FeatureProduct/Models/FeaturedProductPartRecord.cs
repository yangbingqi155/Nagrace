using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Orchard.LearnOrchard.FeatureProduct.Models {
    public class FeaturedProductPartRecord :ContentPartRecord{
        public virtual bool IsOnSale { get; set; }
    }
}