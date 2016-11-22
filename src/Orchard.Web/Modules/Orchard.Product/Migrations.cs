using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Product.Models;
using Orchard.ContentManagement;

namespace Orchard.Product {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            SchemaBuilder.CreateTable(typeof(ProductPartRecord).Name,
                table => table.ContentPartRecord()
                    .Column<int>("SortID")
                );
            
            ContentDefinitionManager.AlterPartDefinition(typeof(ProductPart).Name, builder => {
                builder.WithDescription("Product part for product of site.").WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Product image")
                );
            });

            ContentDefinitionManager.AlterTypeDefinition("Product",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("TitlePart")
                   .WithPart(typeof(ProductPart).Name)
                   .WithPart("LocalizationPart")
                );

            ContentDefinitionManager.AlterTypeDefinition("ProductWidget",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("LocalizationPart")
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                    .WithPart("ProductHomePart")
                );

            return 5;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition(typeof(ProductPart).Name, builder => {
                builder.WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Product image")
                );
            });
            return 2;
        }

        public int UpdateFrom2() {
            ContentDefinitionManager.AlterTypeDefinition("ProductWidget",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                );
            return 3;
        }

        public int UpdateFrom3() {
            ContentDefinitionManager.AlterTypeDefinition("Product",
               cfg => cfg
                  .WithPart("LocalizationPart")
               );
            ContentDefinitionManager.AlterTypeDefinition("ProductWidget",
                cfg => cfg
                    .WithPart("LocalizationPart")
                );
            
            return 4;
        }

        public int UpdateFrom4() {
            ContentDefinitionManager.AlterTypeDefinition("ProductWidget",
                cfg => cfg
                    .WithPart("ProductHomePart")
                );
            return 5;
        }

    }
}