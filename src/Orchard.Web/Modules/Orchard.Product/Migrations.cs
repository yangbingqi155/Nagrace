﻿using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Product.Models;
using Orchard.ContentManagement;

namespace Orchard.Product {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            SchemaBuilder.CreateTable(typeof(ProductPartRecord).Name,
                table => table.ContentPartRecord()
                    .Column<string>("PName")
                    .Column<string>("AbbrePName")
                    .Column<string>("Feature",column=>column.Unlimited())
                    .Column<string>("Spec", column => column.Unlimited())
                    .Column<string>("Package", column => column.Unlimited())
                    .Column<string>("Review", column => column.Unlimited())
                    .Column<int>("SortID")
                );

            ContentDefinitionManager.AlterPartDefinition(typeof(ProductPart).Name, builder => {
                builder.WithDescription("Product part for product of site.").WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Product image")
                );
                builder.WithField("Feature",
                    fieldBuilder =>
                    fieldBuilder.OfType("TextField")
                    .WithDisplayName("Product Feature")
                    .WithSetting("TextFieldSettings.Flavor", "html")
                    .WithSetting("TextFieldSettings.Required", "true")
                );
                builder.WithField("Spec",
                    fieldBuilder =>
                    fieldBuilder.OfType("TextField")
                    .WithDisplayName("Product Spec")
                    .WithSetting("TextFieldSettings.Flavor", "html")
                    .WithSetting("TextFieldSettings.Required", "true")
                );
            });

            ContentDefinitionManager.AlterTypeDefinition("Product",
                cfg => cfg
                    .WithIdentity()
                    .WithPart("TitlePart")
                   .WithPart(typeof(ProductPart).Name)
                   .WithPart("LocalizationPart")
                );
    

            return 2;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition(typeof(ProductPart).Name, builder => {
                builder.WithDescription("Product part for product of site.").WithField("Image",
                    fieldBuilder =>
                    fieldBuilder.OfType("MediaLibraryPickerField")
                    .WithDisplayName("Product image")
                );
                builder.WithField("Feature",
                    fieldBuilder =>
                    fieldBuilder.OfType("TextField")
                    .WithDisplayName("Product Feature")
                    .WithSetting("TextFieldSettings.Flavor", "html")
                    .WithSetting("TextFieldSettings.Required", "true")
                );

                builder.WithField("Spec",
                    fieldBuilder =>
                    fieldBuilder.OfType("TextField")
                    .WithDisplayName("Product Spec")
                    .WithSetting("TextFieldSettings.Flavor", "html")
                    .WithSetting("TextFieldSettings.Required", "true")
                );
            });

          
            return 2;
        }

    }
}