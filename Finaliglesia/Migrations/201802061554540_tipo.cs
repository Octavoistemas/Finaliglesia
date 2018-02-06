namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ceremonias", "Miembro_MiembroID", c => c.Int());
            AddColumn("dbo.Miembroes", "CeremoniasId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ceremonias", "Miembro_MiembroID");
            AddForeignKey("dbo.Ceremonias", "Miembro_MiembroID", "dbo.Miembroes", "MiembroID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ceremonias", "Miembro_MiembroID", "dbo.Miembroes");
            DropIndex("dbo.Ceremonias", new[] { "Miembro_MiembroID" });
            DropColumn("dbo.Miembroes", "CeremoniasId");
            DropColumn("dbo.Ceremonias", "Miembro_MiembroID");
        }
    }
}
