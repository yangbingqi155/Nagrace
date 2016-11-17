using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Advertise.Models;
using Orchard.ContentManagement;

namespace Orchard.Advertise {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            SchemaBuilder.CreateTable(typeof(AdvertisePartRecord).Name,
                table => table.ContentPartRecord()
                    .Column<int>("SortID")
                );
            
            ContentDefinitionManager.AlterPartDefinition(typeof(AdvertisePart).Name, builder => {
                builder.WithDescription("Advertise part for advertise of site.");
            });
            
            ContentDefinitionManager.AlterTypeDefinition("Advertise",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("TitlePart")
                    .RemovePart(typeof(AdvertisePart).Name)
                   .WithPart(typeof(AdvertisePart).Name)
                );

            return 2;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("Advertise",
               cfg => cfg
                   .RemovePart("CommonPart")
                   .RemovePart("AutoroutePart")
                   .RemovePart("MenuPart")
                   .RemovePart("AdminMenuPart")
                   .RemovePart(typeof(AdvertisePart).Name)
                   .WithPart(typeof(AdvertisePart).Name)
               );
            return 2;
        }

    }
}