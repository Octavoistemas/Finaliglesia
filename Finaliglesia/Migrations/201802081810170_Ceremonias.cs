namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ceremonias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", "dbo.Tipoceremonias");
            DropIndex("dbo.Ceremonias", new[] { "Tipoceremonia_TipoceremoniaID" });
            DropColumn("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID");
            DropColumn("dbo.Tipoceremonias", "CeremoniaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tipoceremonias", "CeremoniaId", c => c.Int(nullable: false));
            AddColumn("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", c => c.Int());
            CreateIndex("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID");
            AddForeignKey("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", "dbo.Tipoceremonias", "TipoceremoniaID");
        }
    }
}
