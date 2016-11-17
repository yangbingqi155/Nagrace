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
                   .WithPart(typeof(AdvertisePart).Name)
                );

            return 2;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition(typeof(AdvertisePart).Name, builder => {
                builder.WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Advertise image")
                );
            });
            return 2;
        }
        

    }
}