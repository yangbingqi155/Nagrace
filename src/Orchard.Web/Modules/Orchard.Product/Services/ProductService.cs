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
using Orchard.Product.Models;
using Orchard.Core.Title.Models;
using Orchard.Localization.Models;

namespace Orchard.Product.Services {
    public class ProductService : IProductService {
        private readonly IContentManager _contentManager;
        private readonly IProcessingEngine _processingEngine;
        private readonly ShellSettings _shellSettings;
        private readonly IShellDescriptorManager _shellDescriptorManager;
        private readonly HashSet<int> _processedProductParts = new HashSet<int>();
        IPathResolutionService _pathResolutionService;

        public ProductService(
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

        public ProductPart Get(string path) {
            var product = _pathResolutionService.GetPath(path);

            if (product == null) {
                return null;
            }

            if (!product.Has<ProductPart>()) {
                return null;
            }

            return product.As<ProductPart>();
        }

        public ContentItem Get(int id, VersionOptions versionOptions) {
            var productPart = _contentManager.Get<ProductPart>(id, versionOptions);
            return productPart == null ? null : productPart.ContentItem;
        }

        public IEnumerable<ProductPart> Get() {
            return Get(VersionOptions.Published);
        }

        public IEnumerable<ProductPart> Get(VersionOptions versionOptions) {
            return _contentManager.Query<ProductPart>(versionOptions, "Product")
                .Join<TitlePartRecord>()
                .OrderBy(br => br.Title)
                .List();
        }

        public IEnumerable<ProductPart> Get(VersionOptions versionOptions,int cultureId) {
            return _contentManager.Query<ProductPart>(versionOptions, "Product")
                .Join<LocalizationPartRecord>()
                .Where(en=>en.CultureId== cultureId)
                .List();
        }

        public void Delete(ContentItem productment) {
            _contentManager.Remove(productment);
        }
    }
}