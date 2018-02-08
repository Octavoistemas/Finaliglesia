namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iglesias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ceremonias", "Iglesia_IglesiaID", "dbo.Iglesias");
            DropIndex("dbo.Ceremonias", new[] { "Iglesia_IglesiaID" });
            AddColumn("dbo.Iglesias", "Ceremonia_CeremoniaID", c => c.Int());
            AddColumn("dbo.Ceremonias", "iglesiaid", c => c.Int(nullable: false));
            CreateIndex("dbo.Iglesias", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Iglesias", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
            DropColumn("dbo.Iglesias", "ceremoniaId");
            DropColumn("dbo.Ceremonias", "Iglesia_IglesiaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ceremonias", "Iglesia_IglesiaID", c => c.Int());
            AddColumn("dbo.Iglesias", "ceremoniaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Iglesias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Iglesias", new[] { "Ceremonia_CeremoniaID" });
            DropColumn("dbo.Ceremonias", "iglesiaid");
            DropColumn("dbo.Iglesias", "Ceremonia_CeremoniaID");
            CreateIndex("dbo.Ceremonias", "Iglesia_IglesiaID");
            AddForeignKey("dbo.Ceremonias", "Iglesia_IglesiaID", "dbo.Iglesias", "IglesiaID");
        }
    }
}
