using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.Advertise.Models;
using Orchard.ContentManagement;

namespace Orchard.Advertise.Services {
    public interface IAdvertiseService : IDependency {
        AdvertisePart Get(string path);
        ContentItem Get(int id, VersionOptions versionOptions);
        IEnumerable<AdvertisePart> Get();
        IEnumerable<AdvertisePart> Get(VersionOptions versionOptions);
        void Delete(ContentItem blog);
    }
}
