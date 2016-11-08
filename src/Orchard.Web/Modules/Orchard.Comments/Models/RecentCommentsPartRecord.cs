using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Orchard.Comments.Models {
    public class RecentCommentsPartRecord:ContentPartRecord {
        public RecentCommentsPartRecord() {
            Count = 5;
        }

        public virtual int ContainerID { get; set; }

        public virtual int Count { get; set; }
    }
}