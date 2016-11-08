﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.LearnOrchard.FeatureProduct.Models;

namespace Orchard.LearnOrchard.FeatureProduct.Handlers {
    public class FeaturedProductHandler :ContentHandler {

        public FeaturedProductHandler(IRepository<FeaturedProductPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }

    }
}