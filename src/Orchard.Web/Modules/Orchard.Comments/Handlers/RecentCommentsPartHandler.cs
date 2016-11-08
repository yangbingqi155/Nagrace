using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Comments.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Orchard.Comments.Handlers {
    public class RecentCommentsPartHandler :ContentHandler{
        public RecentCommentsPartHandler(IRepository<RecentCommentsPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}