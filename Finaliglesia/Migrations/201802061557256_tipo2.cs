namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropIndex("dbo.Ceremonias", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            CreateTable(
                "dbo.MiembroCeremoniaCeremonias",
                c => new
                    {
                        MiembroCeremonia_MiembroCeremoniaID = c.Int(nullable: false),
                        Ceremonia_CeremoniaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MiembroCeremonia_MiembroCeremoniaID, t.Ceremonia_CeremoniaID })
                .ForeignKey("dbo.MiembroCeremonias", t => t.MiembroCeremonia_MiembroCeremoniaID, cascadeDelete: true)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID, cascadeDelete: true)
                .Index(t => t.MiembroCeremonia_MiembroCeremoniaID)
                .Index(t => t.Ceremonia_CeremoniaID);
            
            AddColumn("dbo.Ceremonias", "MiembroCeremoniaId", c => c.Int(nullable: false));
            DropColumn("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", c => c.Int());
            DropForeignKey("dbo.MiembroCeremoniaCeremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.MiembroCeremoniaCeremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropIndex("dbo.MiembroCeremoniaCeremonias", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.MiembroCeremoniaCeremonias", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            DropColumn("dbo.Ceremonias", "MiembroCeremoniaId");
            DropTable("dbo.MiembroCeremoniaCeremonias");
            CreateIndex("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID");
            AddForeignKey("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias", "MiembroCeremoniaID");
        }
    }
}
