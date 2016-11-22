using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Orchard.Product.Models {
    public class ProductPartRecord : ContentPartRecord{
        //排序ID
        public virtual int SortID { get; set; }
    }
}