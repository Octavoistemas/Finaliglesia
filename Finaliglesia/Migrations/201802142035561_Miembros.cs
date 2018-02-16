namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Miembros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Miembroes", "Rol", c => c.String());
            DropColumn("dbo.MiembroCeremonias", "Rol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MiembroCeremonias", "Rol", c => c.String());
            DropColumn("dbo.Miembroes", "Rol");
        }
    }
}
