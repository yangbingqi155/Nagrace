using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

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
        
        //排序ID
        public virtual int SortID { get; set; }


    }
}