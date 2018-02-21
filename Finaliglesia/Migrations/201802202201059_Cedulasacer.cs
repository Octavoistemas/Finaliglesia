namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cedulasacer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cedula", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Cedula");
        }
    }
}