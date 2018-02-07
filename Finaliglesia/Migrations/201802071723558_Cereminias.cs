namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cereminias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Iglesias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Iglesias", new[] { "Ceremonia_CeremoniaID" });
            AddColumn("dbo.Iglesias", "ceremoniaId", c => c.Int(nullable: false));
            AddColumn("dbo.Ceremonias", "Iglesia_IglesiaID", c => c.Int());
            CreateIndex("dbo.Ceremonias", "Iglesia_IglesiaID");
            AddForeignKey("dbo.Ceremonias", "Iglesia_IglesiaID", "dbo.Iglesias", "IglesiaID");
            DropColumn("dbo.Iglesias", "Ceremonia_CeremoniaID");
            DropColumn("dbo.Ceremonias", "IglesiasId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ceremonias", "IglesiasId", c => c.Int(nullable: false));
            AddColumn("dbo.Iglesias", "Ceremonia_CeremoniaID", c => c.Int());
            DropForeignKey("dbo.Ceremonias", "Iglesia_IglesiaID", "dbo.Iglesias");
            DropIndex("dbo.Ceremonias", new[] { "Iglesia_IglesiaID" });
            DropColumn("dbo.Ceremonias", "Iglesia_IglesiaID");
            DropColumn("dbo.Iglesias", "ceremoniaId");
            CreateIndex("dbo.Iglesias", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Iglesias", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
        }
    }
}
