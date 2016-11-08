using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Orchard.Advertise {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageAdvertise = new Permission { Description = "Manage Advertise for others", Name = "ManageAdvertise" };
        public static readonly Permission ManageOwnAdvertise = new Permission { Description = "Manage own Advertise", Name = "ManageOwnAdvertise", ImpliedBy = new[] { ManageAdvertise } };
        
        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageAdvertise,
                ManageOwnAdvertise
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageOwnAdvertise }
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] { ManageOwnAdvertise }
                },
                new PermissionStereotype {
                    Name = "Moderator",
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] { ManageOwnAdvertise }
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] {ManageOwnAdvertise}
                },
            };
        }

    }
}


