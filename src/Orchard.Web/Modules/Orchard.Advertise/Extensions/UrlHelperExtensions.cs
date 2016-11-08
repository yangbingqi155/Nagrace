using System.Web;
using System.Web.Mvc;
using Orchard.Advertise.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Mvc.Extensions;

namespace Orchard.Advertise.Extensions {
    /// <summary>
    /// TODO: (PH:Autoroute) Many of these are or could be redundant (see controllers)
    /// </summary>
    public static class UrlHelperExtensions {
        public static string Advertises(this UrlHelper urlHelper) {
            return urlHelper.Action("List", "Advertise", new {area = "Orchard.Advertise" });
        }

        public static string AdvertisesForAdmin(this UrlHelper urlHelper) {
            return urlHelper.Action("List", "AdvertiseAdmin", new {area = "Orchard.Advertise" });
        }

        public static string Advertise(this UrlHelper urlHelper, AdvertisePart advertisePart) {
            return urlHelper.Action("Item", "Advertise", new { advertiseId = advertisePart.Id, area = "Orchard.Advertise" });
        }
        

        public static string AdvertiseForAdmin(this UrlHelper urlHelper, AdvertisePart advertisePart) {
            return urlHelper.Action("Item", "AdvertiseAdmin", new { advertiseId = advertisePart.Id, area = "Orchard.Advertise" });
        }

        public static string AdvertiseCreate(this UrlHelper urlHelper) {
            return urlHelper.Action("Create", "AdvertiseAdmin", new { area = "Orchard.Advertise" });
        }

        public static string AdvertiseEdit(this UrlHelper urlHelper, AdvertisePart advertisePart) {
            return urlHelper.Action("Edit", "AdvertiseAdmin", new { advertiseId = advertisePart.Id, area = "Orchard.Advertise" });
        }

        public static string AdvertiseRemove(this UrlHelper urlHelper, AdvertisePart advertisePart) {
            return urlHelper.Action("Remove", "AdvertiseAdmin", new { advertiseId = advertisePart.Id, area = "Orchard.Advertise" });
        }
    }
}