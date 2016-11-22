using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.Product.Models;
using Orchard.ContentManagement;

namespace Orchard.Product.Services {
    public interface IProductService : IDependency {
        ProductPart Get(string path);
        ContentItem Get(int id, VersionOptions versionOptions);
        IEnumerable<ProductPart> Get();
        IEnumerable<ProductPart> Get(VersionOptions versionOptions);
        IEnumerable<ProductPart> Get(VersionOptions versionOptions, int cultureId);
        void Delete(ContentItem product);
    }
}
