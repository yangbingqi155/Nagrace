using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Orchard.Advertise.Models;
using Orchard.ContentManagement;
using Orchard.Alias;
using Orchard.Localization.Models;
using Orchard.Advertise.Services;

namespace Orchard.Advertise.Drivers {
    public class AdvertiseHomePartDriver : ContentPartDriver<AdvertiseHomePart> {
        IAdvertiseService _advertiseService = null;
        IContentManager _contentManager;
        private IContent _currentContent = null;
        private IAliasService _aliasService = null;
        private IWorkContextAccessor _workContextAccessor = null;

        public AdvertiseHomePartDriver(IContentManager contentManager, IAliasService aliasService, IWorkContextAccessor workContextAccessor, IAdvertiseService advertiseService) {
            _contentManager = contentManager;
            _aliasService = aliasService;
            _workContextAccessor = workContextAccessor;
            _advertiseService = advertiseService;
        }

        
        private IContent CurrentContent
        {
            get
            {
                if (_currentContent == null) {
                    var itemRoute = _aliasService.Get(_workContextAccessor.GetContext()
                      .HttpContext.Request.AppRelativeCurrentExecutionFilePath
                      .Substring(1).Trim('/'));

                    _currentContent = _contentManager.Get(Convert.ToInt32(itemRoute["Id"]));
                }

                return _currentContent;
            }
        }

        protected override DriverResult Display(AdvertiseHomePart part, string displayType, dynamic shapeHelper) {
            
            int cultureId = CurrentContent.As<LocalizationPart>().Culture.Id;

            IEnumerable<AdvertisePart> parts= _advertiseService.Get(VersionOptions.AllVersions,cultureId);
       
            return ContentShape("Parts_AdvertiseHome", () => {

                return shapeHelper.Parts_AdvertiseHome(
                    AdvertiseParts: parts);

            });
        }

        //protected override DriverResult Editor(AdvertiseHomePart part, dynamic shapeHelper) {

        //    return ContentShape("Parts_Advertise_Edit", () =>
        //         shapeHelper.EditorTemplate(TemplateName: "Parts.Advertise", Model: part, Prefix: Prefix)
        //    );
        //}

        //protected override DriverResult Editor(AdvertiseHomePart part, IUpdateModel updater, dynamic shapeHelper) {
        //    updater.TryUpdateModel(part, Prefix, null, null);
        //    return Editor(part, shapeHelper);

        //}
    }
}