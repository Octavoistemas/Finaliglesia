namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoiglesia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Iglesias", "Direccion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Iglesias", "Direccion", c => c.Int(nullable: false));
        }
    }
}
