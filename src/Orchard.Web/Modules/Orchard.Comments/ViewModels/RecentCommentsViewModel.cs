using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.Blogs.Models;

namespace Orchard.Comments.ViewModels {
    public class RecentCommentsViewModel {
        [Required]
        public int ContainerID { get; set; }

        [Required]
        public int Count { get; set; }

        public IEnumerable<BlogPart> Blogs { get; set; }
    }
}