namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cereminias2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MiembroCeremoniaCeremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropForeignKey("dbo.MiembroCeremoniaCeremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.MiembroCeremoniaCeremonias", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            DropIndex("dbo.MiembroCeremoniaCeremonias", new[] { "Ceremonia_CeremoniaID" });
            AddColumn("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", c => c.Int());
            CreateIndex("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID");
            AddForeignKey("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias", "MiembroCeremoniaID");
            DropColumn("dbo.Ceremonias", "MiembroCeremoniaId");
            DropTable("dbo.MiembroCeremoniaCeremonias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MiembroCeremoniaCeremonias",
                c => new
                    {
                        MiembroCeremonia_MiembroCeremoniaID = c.Int(nullable: false),
                        Ceremonia_CeremoniaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MiembroCeremonia_MiembroCeremoniaID, t.Ceremonia_CeremoniaID });
            
            AddColumn("dbo.Ceremonias", "MiembroCeremoniaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropIndex("dbo.Ceremonias", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            DropColumn("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID");
            CreateIndex("dbo.MiembroCeremoniaCeremonias", "Ceremonia_CeremoniaID");
            CreateIndex("dbo.MiembroCeremoniaCeremonias", "MiembroCeremonia_MiembroCeremoniaID");
            AddForeignKey("dbo.MiembroCeremoniaCeremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID", cascadeDelete: true);
            AddForeignKey("dbo.MiembroCeremoniaCeremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias", "MiembroCeremoniaID", cascadeDelete: true);
        }
    }
}
