namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nose : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ceremonias", "TipoCeremoniasId", c => c.Int(nullable: false));
            AddColumn("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", c => c.Int());
            CreateIndex("dbo.Tipoceremonias", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Tipoceremonias", new[] { "Ceremonia_CeremoniaID" });
            DropColumn("dbo.Tipoceremonias", "Ceremonia_CeremoniaID");
            DropColumn("dbo.Ceremonias", "TipoCeremoniasId");
        }
    }
}
