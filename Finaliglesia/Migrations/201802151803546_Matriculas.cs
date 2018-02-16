namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matriculas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MiembroMatriculas", "MiembrosId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MiembroMatriculas", "MiembrosId", c => c.Int(nullable: false));
        }
    }
}
