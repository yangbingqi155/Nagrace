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

        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("The name of product")]
        [Required]
        public string PName
        {
            get { return Retrieve(r => r.PName); }
            set { Store(r => r.PName, value); }
        }

        /// <summary>
        /// 产品简称
        /// </summary>
        [DisplayName("The abbreviation name of product")]
        [Required]
        public  string AbbrePName
        {
            get { return Retrieve(r => r.AbbrePName); }
            set { Store(r => r.AbbrePName, value); }
        }

    }
}