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

        /// <summary>
        /// 产品特性
        /// </summary>
        [DisplayName("The feature of product")]
        [Required]
        public string Feature
        {
            get { return Retrieve(r => r.Feature); }
            set { Store(r => r.Feature, value); }
        }

        /// <summary>
        /// 产品特性
        /// </summary>
        [DisplayName("The spec of product")]
        [Required]
        public string Spec
        {
            get { return Retrieve(r => r.Spec); }
            set { Store(r => r.Spec, value); }
        }

        /// <summary>
        /// 下载包
        /// </summary>
        [DisplayName("The package of product")]
        [Required]
        public string Package
        {
            get { return Retrieve(r => r.Package); }
            set { Store(r => r.Package, value); }
        }

        /// <summary>
        /// 回顾
        /// </summary>
        [DisplayName("The review of product")]
        [Required]
        public string Review
        {
            get { return Retrieve(r => r.Review); }
            set { Store(r => r.Review, value); }
        }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("Order of products,order rule is AESC")]
        [Required]
        public int SortID
        {
            get { return Retrieve(r => r.SortID); }
            set { Store(r => r.SortID, value); }
        }

    }
}