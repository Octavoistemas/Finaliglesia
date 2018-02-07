namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Horarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Horarios", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Horarios", new[] { "Ceremonia_CeremoniaID" });
            AddColumn("dbo.Ceremonias", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ceremonias", "Hora", c => c.String());
            DropColumn("dbo.Ceremonias", "HoraiosId");
            DropTable("dbo.Horarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        HorarioID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Ceremonia_CeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.HorarioID);
            
            AddColumn("dbo.Ceremonias", "HoraiosId", c => c.Int(nullable: false));
            DropColumn("dbo.Ceremonias", "Hora");
            DropColumn("dbo.Ceremonias", "Fecha");
            CreateIndex("dbo.Horarios", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Horarios", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
        }
    }
}
