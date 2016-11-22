using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace Orchard.Product.Models {
    public class ProductPart : ContentPart<ProductPartRecord> {
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("Order of product,order rule is AESC")]
        [Required]
        public int SortID {
            get { return Retrieve(r => r.SortID); }
            set { Store(r => r.SortID, value); }
        }
    }
}