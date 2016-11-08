using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;
using Orchard.Advertise.Services;

namespace Orchard.Advertise {
    public class AdminMenu:INavigationProvider {

        private readonly IAdvertiseService _advertiseService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IWorkContextAccessor _workContextAccessor;

        public AdminMenu(IAdvertiseService advertiseService, IAuthorizationService authorizationService, IWorkContextAccessor workContextAccessor) {
            _advertiseService = advertiseService;
            _authorizationService = authorizationService;
            _workContextAccessor = workContextAccessor;
        }

        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Advertise"), "1.5", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu) {
            var advertises = _advertiseService.Get().Where(x => _authorizationService.TryCheckAccess(Permissions.ManageAdvertise, _workContextAccessor.GetContext().CurrentUser, x)).ToArray();
            var advertiseCount = advertises.Count();
            var singleAdvertise = advertiseCount == 1 ? advertises.ElementAt(0) : null;

            if (advertiseCount > 0 && singleAdvertise == null) {
                menu.Add(T("Manage Advertises"), "3",
                         item => item.Action("List", "AdvertiseAdmin", new { area = "Orchard.Advertise" }).Permission(Permissions.ManageAdvertise));
            }
            else if (singleAdvertise != null)
                menu.Add(T("Manage Advertise"), "1.0",
                    item => item.Action("Item", "AdvertiseAdmin", new { area = "Orchard.Advertise", advertiseId = singleAdvertise.Id }).Permission(Permissions.ManageOwnAdvertise));

            menu.Add(T("New Advertise"), "1.2",
                    item =>
                    item.Action("Create", "AdvertiseAdmin", new { area = "Orchard.Advertise" }).Permission(Permissions.ManageAdvertise));



        }
    }
}