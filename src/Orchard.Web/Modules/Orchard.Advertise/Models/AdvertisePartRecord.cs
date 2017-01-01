using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Orchard.Advertise.Models {
    public class AdvertisePartRecord :ContentPartRecord{
        //排序ID
        public virtual int SortID { get; set; }

        public virtual string Link { get; set; }
    }
}