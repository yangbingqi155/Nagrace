using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace Orchard.Advertise.Models {
    public class AdvertisePart :ContentPart<AdvertisePartRecord>{
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("Order of advertise,order rule is AESC")]
        [Required]
        public int SortID {
            get { return Retrieve(r => r.SortID); }
            set { Store(r => r.SortID, value); }
        }
        /// <summary>
        /// 链接
        /// </summary>
        [DisplayName("Link of advertise ")]
        public string Link
        {
            get { return Retrieve(r => r.Link); }
            set { Store(r => r.Link, value); }
        }

    }
}