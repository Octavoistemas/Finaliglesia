namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miembrosceremosnias : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MiembroCeremonias", "MiembrosId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MiembroCeremonias", "MiembrosId", c => c.Int(nullable: false));
        }
    }
}
