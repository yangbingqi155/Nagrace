﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.LearnOrchard.FeatureProduct.Services {
    public interface IFeaturedProductService :IDependency{
        bool IsOnFeaturedProductPage();
    }
}
