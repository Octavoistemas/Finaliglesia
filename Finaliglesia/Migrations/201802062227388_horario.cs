namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class horario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Horarios", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Horarios", "Email", c => c.String());
        }
    }
}
