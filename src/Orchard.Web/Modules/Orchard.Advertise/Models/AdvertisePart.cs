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
            get { return Record.SortID; }
            set { Record.SortID=value; }
        }
    }
}