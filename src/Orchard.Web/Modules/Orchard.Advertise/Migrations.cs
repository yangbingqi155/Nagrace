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
                    .Column<string>("Link")
                );
            
            ContentDefinitionManager.AlterPartDefinition(typeof(AdvertisePart).Name, builder => {
                builder.WithDescription("Advertise part for advertise of site.").WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Advertise image")
                );
            });

            ContentDefinitionManager.AlterTypeDefinition("Advertise",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("TitlePart")
                   .WithPart(typeof(AdvertisePart).Name)
                   .WithPart("LocalizationPart")
                );

            ContentDefinitionManager.AlterTypeDefinition("AdvertiseWidget",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("LocalizationPart")
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                    .WithPart("AdvertiseHomePart")
                );

            return 6;
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

        public int UpdateFrom2() {
            ContentDefinitionManager.AlterTypeDefinition("AdvertiseWidget",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                );
            return 3;
        }

        public int UpdateFrom3() {
            ContentDefinitionManager.AlterTypeDefinition("Advertise",
               cfg => cfg
                  .WithPart("LocalizationPart")
               );
            ContentDefinitionManager.AlterTypeDefinition("AdvertiseWidget",
                cfg => cfg
                    .WithPart("LocalizationPart")
                );
            
            return 4;
        }

        public int UpdateFrom4() {
            ContentDefinitionManager.AlterTypeDefinition("AdvertiseWidget",
                cfg => cfg
                    .WithPart("AdvertiseHomePart")
                );
            return 5;
        }

        public int UpdateFrom5() {
            SchemaBuilder.AlterTable(typeof(AdvertisePartRecord).Name,
                table => table.AddColumn<string>("Link")
                );
            return 6;
        }

    }
}