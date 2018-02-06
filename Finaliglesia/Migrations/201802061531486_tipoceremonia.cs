namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoceremonia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Tipoceremonias", new[] { "Ceremonia_CeremoniaID" });
            AddColumn("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", c => c.Int());
            AddColumn("dbo.Tipoceremonias", "CeremoniaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID");
            AddForeignKey("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", "dbo.Tipoceremonias", "TipoceremoniaID");
            DropColumn("dbo.Ceremonias", "TipoCeremoniaID");
            DropColumn("dbo.Tipoceremonias", "Ceremonia_CeremoniaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", c => c.Int());
            AddColumn("dbo.Ceremonias", "TipoCeremoniaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID", "dbo.Tipoceremonias");
            DropIndex("dbo.Ceremonias", new[] { "Tipoceremonia_TipoceremoniaID" });
            DropColumn("dbo.Tipoceremonias", "CeremoniaId");
            DropColumn("dbo.Ceremonias", "Tipoceremonia_TipoceremoniaID");
            CreateIndex("dbo.Tipoceremonias", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
        }
    }
}
