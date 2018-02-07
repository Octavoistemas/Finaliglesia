namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturaceremonia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropIndex("dbo.Facturas", new[] { "Ceremonia_CeremoniaID" });
            AddColumn("dbo.Ceremonias", "Factura_FacturaID", c => c.Int());
            AddColumn("dbo.Facturas", "CeremoniaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ceremonias", "Factura_FacturaID");
            AddForeignKey("dbo.Ceremonias", "Factura_FacturaID", "dbo.Facturas", "FacturaID");
            DropColumn("dbo.Ceremonias", "FacturasId");
            DropColumn("dbo.Facturas", "Ceremonia_CeremoniaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Ceremonia_CeremoniaID", c => c.Int());
            AddColumn("dbo.Ceremonias", "FacturasId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ceremonias", "Factura_FacturaID", "dbo.Facturas");
            DropIndex("dbo.Ceremonias", new[] { "Factura_FacturaID" });
            DropColumn("dbo.Facturas", "CeremoniaId");
            DropColumn("dbo.Ceremonias", "Factura_FacturaID");
            CreateIndex("dbo.Facturas", "Ceremonia_CeremoniaID");
            AddForeignKey("dbo.Facturas", "Ceremonia_CeremoniaID", "dbo.Ceremonias", "CeremoniaID");
        }
    }
}
