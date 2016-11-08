using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Orchard.Comments.Models {
    public class RecentCommentsPart:ContentPart<RecentCommentsPartRecord> {
        [Required]
        public int ContainerID {
            get { return Record.ContainerID; }
            set { Record.ContainerID = value; }
        }
        
        [Required]
        public int Count
        {
            get { return Record.Count; }
            set { Record.Count = value; }
        }
    }
}