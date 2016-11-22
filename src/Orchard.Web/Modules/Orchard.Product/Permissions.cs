using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Orchard.Product {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageProduct = new Permission { Description = "Manage Product for others", Name = "ManageProduct" };
        public static readonly Permission ManageOwnProduct = new Permission { Description = "Manage own Product", Name = "ManageOwnProduct", ImpliedBy = new[] { ManageProduct } };
        
        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageProduct,
                ManageOwnProduct
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageOwnProduct }
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] { ManageOwnProduct }
                },
                new PermissionStereotype {
                    Name = "Moderator",
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] { ManageOwnProduct }
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] {ManageOwnProduct}
                },
            };
        }

    }
}


