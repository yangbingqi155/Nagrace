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
                    .WithPart(typeof(AdvertisePart).Name)
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "True")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "False")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{\"Name\":\"Title\",\"Pattern\":\"{Content.Slug}\",\"Description\":\"my-advertise\"}]"))
                    .WithPart("MenuPart")
                    .WithPart("AdminMenuPart", p => p.WithSetting("AdminMenuPartTypeSettings.DefaultPosition", "2"))
                );

            return 4;
        }

        public int UpdateFrom1() {
            SchemaBuilder.CreateTable(typeof(AdvertisePartRecord).Name,
               table => table
                   .Column<int>("SortID")
               );

            ContentDefinitionManager.AlterPartDefinition(typeof(AdvertisePart).Name, builder => {
                builder.WithDescription("Advertise part for advertise of site.");
            });

            ContentDefinitionManager.AlterTypeDefinition("Advertise", builder => {
                builder.WithPart(typeof(AdvertisePart).Name).WithPart("CommonPart")
                    .WithPart("TitlePart");
            });

            return 2;
        }


        public int UpdateFrom2() {
            ContentDefinitionManager.AlterTypeDefinition("Advertise",
                cfg => cfg
                    .WithPart(typeof(AdvertisePart).Name)
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "True")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "False")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{\"Name\":\"Title\",\"Pattern\":\"{Content.Slug}\",\"Description\":\"my-advertise\"}]"))
                    .WithPart("MenuPart")
                    .WithPart("AdminMenuPart", p => p.WithSetting("AdminMenuPartTypeSettings.DefaultPosition", "2"))
                );

     

            return 3;
        }

        public int UpdateFrom3() {
            ContentDefinitionManager.AlterTypeDefinition("Advertise",
                cfg => cfg
                    .WithIdentity()
                );



            return 4;
        }
        

      
    }
}