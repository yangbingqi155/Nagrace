using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Product.Models {
    public class ProductPartRecord : ContentPartRecord{
        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string PName { get; set; }

        /// <summary>
        /// 产品简称
        /// </summary>
        public virtual string AbbrePName { get; set; }

        /// <summary>
        /// 产品特性
        /// </summary>
        [StringLengthMax]
        public virtual string Feature { get; set; }

        /// <summary>
        /// 产品参数
        /// </summary>
        [StringLengthMax]
        public virtual string Spec { get; set; }

        /// <summary>
        /// 下载包
        /// </summary>
        [StringLengthMax]
        public virtual string Package { get; set; }

        /// <summary>
        /// 回顾
        /// </summary>
        [StringLengthMax]
        public virtual string Review { get; set; }
        
        //排序ID
        public virtual int SortID { get; set; }


    }
}