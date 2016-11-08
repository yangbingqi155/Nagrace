using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Advertise.Models;
using Orchard.Data;
using System.Web.Routing;

namespace Orchard.Advertise.Handlers {
    public class AdvertisePartHandler:ContentHandler {
        public AdvertisePartHandler(IRepository<AdvertisePartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnGetDisplayShape<AdvertisePart>((context, advertise) => {
            });
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var advertise = context.ContentItem.As<AdvertisePart>();

            if (advertise == null)
                return;

            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Advertise"},
                {"Controller", "Advertise"},
                {"Action", "Item"},
                {"advertiseId", context.ContentItem.Id}
            };
            context.Metadata.CreateRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Advertise"},
                {"Controller", "AdvertiseAdmin"},
                {"Action", "Create"}
            };
            context.Metadata.EditorRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Advertise"},
                {"Controller", "AdvertiseAdmin"},
                {"Action", "Edit"},
                {"advertiseId", context.ContentItem.Id}
            };
            context.Metadata.RemoveRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Advertise"},
                {"Controller", "AdvertiseAdmin"},
                {"Action", "Remove"},
                {"advertiseId", context.ContentItem.Id}
            };
            context.Metadata.AdminRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Advertise"},
                {"Controller", "AdvertiseAdmin"},
                {"Action", "Item"},
                {"advertiseId", context.ContentItem.Id}
            };
        }
    }
}