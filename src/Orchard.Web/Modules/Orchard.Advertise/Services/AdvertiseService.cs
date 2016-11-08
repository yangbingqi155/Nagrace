using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Autoroute.Services;
using Orchard.ContentManagement;
using Orchard.Environment.Configuration;
using Orchard.Environment.Descriptor;
using Orchard.Environment.State;
using Orchard.Services;
using Orchard.Advertise.Models;
using Orchard.Core.Title.Models;

namespace Orchard.Advertise.Services {
    public class AdvertiseService : IAdvertiseService {
        private readonly IContentManager _contentManager;
        private readonly IProcessingEngine _processingEngine;
        private readonly ShellSettings _shellSettings;
        private readonly IShellDescriptorManager _shellDescriptorManager;
        private readonly HashSet<int> _processedBlogParts = new HashSet<int>();
        IPathResolutionService _pathResolutionService;

        public AdvertiseService(
            IContentManager contentManager,
            IProcessingEngine processingEngine,
            ShellSettings shellSettings,
            IShellDescriptorManager shellDescriptorManager,
            IPathResolutionService pathResolutionService) {
            _contentManager = contentManager;
            _processingEngine = processingEngine;
            _shellSettings = shellSettings;
            _shellDescriptorManager = shellDescriptorManager;
            _pathResolutionService = pathResolutionService;
        }

        public AdvertisePart Get(string path) {
            var advertise = _pathResolutionService.GetPath(path);

            if (advertise == null) {
                return null;
            }

            if (!advertise.Has<AdvertisePart>()) {
                return null;
            }

            return advertise.As<AdvertisePart>();
        }

        public ContentItem Get(int id, VersionOptions versionOptions) {
            var blogPart = _contentManager.Get<AdvertisePart>(id, versionOptions);
            return blogPart == null ? null : blogPart.ContentItem;
        }

        public IEnumerable<AdvertisePart> Get() {
            return Get(VersionOptions.Published);
        }

        public IEnumerable<AdvertisePart> Get(VersionOptions versionOptions) {
            return _contentManager.Query<AdvertisePart>(versionOptions, "Advertise")
                .Join<TitlePartRecord>()
                .OrderBy(br => br.Title)
                .List();
        }

        public void Delete(ContentItem advertisement) {
            _contentManager.Remove(advertisement);
        }
    }
}