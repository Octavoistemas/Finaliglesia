namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Miembros : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ceremonias", "Miembro_MiembroID", "dbo.Miembroes");
            DropIndex("dbo.Ceremonias", new[] { "Miembro_MiembroID" });
            DropColumn("dbo.Ceremonias", "Miembro_MiembroID");
            DropColumn("dbo.Miembroes", "CeremoniasId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miembroes", "CeremoniasId", c => c.Int(nullable: false));
            AddColumn("dbo.Ceremonias", "Miembro_MiembroID", c => c.Int());
            CreateIndex("dbo.Ceremonias", "Miembro_MiembroID");
            AddForeignKey("dbo.Ceremonias", "Miembro_MiembroID", "dbo.Miembroes", "MiembroID");
        }
    }
}
