using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Common.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.LearnOrchard.FeatureProduct.Models;
using Orchard.Widgets.Models;

namespace Orchard.LearnOrchard.FeatureProduct {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            ContentDefinitionManager.AlterTypeDefinition(
            "FeaturedProductWidget", cfg => cfg
              .WithSetting("Stereotype", "Widget")
              .WithPart(typeof(FeaturedProductPart).Name)
              .WithPart(typeof(CommonPart).Name)
              .WithPart(typeof(WidgetPart).Name));

            ContentDefinitionManager.AlterPartDefinition(typeof(FeaturedProductPart).Name, part => part.WithDescription("Renders information about the current featured product."));

            SchemaBuilder.CreateTable(typeof(FeaturedProductPartRecord).Name, table => table
            .ContentPartRecord()
            .Column<bool>("IsOnSale")
            );
           

            return 3;
        }

        //
        public int UpdateFrom1() {
            SchemaBuilder.CreateTable(typeof(FeaturedProductPartRecord).Name, table => table
            .ContentPartRecord()
            .Column<bool>("IsOnSale")
            );
            return 2;
        }

        public int UpdateFrom2() {
            ContentDefinitionManager.AlterPartDefinition(typeof(FeaturedProductPart).Name, part => part.WithDescription("Renders information about the current featured product."));
            return 3;
        }
    }
}