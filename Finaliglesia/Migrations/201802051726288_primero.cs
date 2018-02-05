namespace Finaliglesia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        cargoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Directiva_DirectivaID = c.Int(),
                    })
                .PrimaryKey(t => t.cargoID)
                .ForeignKey("dbo.Directivas", t => t.Directiva_DirectivaID)
                .Index(t => t.Directiva_DirectivaID);
            
            CreateTable(
                "dbo.Catequistas",
                c => new
                    {
                        CatequistaID = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Email = c.String(),
                        IglesiasId = c.Int(nullable: false),
                        Matricula_MatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.CatequistaID)
                .ForeignKey("dbo.Matriculas", t => t.Matricula_MatriculaID)
                .Index(t => t.Matricula_MatriculaID);
            
            CreateTable(
                "dbo.Iglesias",
                c => new
                    {
                        IglesiaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.Int(nullable: false),
                        TipoIglesiasId = c.Int(nullable: false),
                        Catequista_CatequistaID = c.Int(),
                        Ceremonia_CeremoniaID = c.Int(),
                        Directiva_DirectivaID = c.Int(),
                        Matricula_MatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.IglesiaID)
                .ForeignKey("dbo.Catequistas", t => t.Catequista_CatequistaID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .ForeignKey("dbo.Directivas", t => t.Directiva_DirectivaID)
                .ForeignKey("dbo.Matriculas", t => t.Matricula_MatriculaID)
                .Index(t => t.Catequista_CatequistaID)
                .Index(t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Directiva_DirectivaID)
                .Index(t => t.Matricula_MatriculaID);
            
            CreateTable(
                "dbo.Tipoiglesias",
                c => new
                    {
                        TipoiglesiaID = c.Int(nullable: false, identity: true),
                        Detalle = c.String(),
                        Iglesia_IglesiaID = c.Int(),
                    })
                .PrimaryKey(t => t.TipoiglesiaID)
                .ForeignKey("dbo.Iglesias", t => t.Iglesia_IglesiaID)
                .Index(t => t.Iglesia_IglesiaID);
            
            CreateTable(
                "dbo.Ceremonias",
                c => new
                    {
                        CeremoniaID = c.Int(nullable: false, identity: true),
                        TipoCeremoniaID = c.Int(nullable: false),
                        IglesiasId = c.Int(nullable: false),
                        HoraiosId = c.Int(nullable: false),
                        SacramentosId = c.Int(nullable: false),
                        FacturasId = c.Int(nullable: false),
                        SacerdotesId = c.Int(nullable: false),
                        MiembroCeremonia_MiembroCeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.CeremoniaID)
                .ForeignKey("dbo.MiembroCeremonias", t => t.MiembroCeremonia_MiembroCeremoniaID)
                .Index(t => t.MiembroCeremonia_MiembroCeremoniaID);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DetalleFactura = c.String(),
                        Ceremonia_CeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Ceremonia_CeremoniaID);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        HorarioID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Ceremonia_CeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.HorarioID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Ceremonia_CeremoniaID);
            
            CreateTable(
                "dbo.Sacerdotes",
                c => new
                    {
                        SacerdoteID = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        NombreSacerdote = c.String(),
                        ApellidoSacerdote = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        email = c.String(),
                        Ceremonia_CeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.SacerdoteID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Ceremonia_CeremoniaID);
            
            CreateTable(
                "dbo.Sacramentoes",
                c => new
                    {
                        SacramentoID = c.Int(nullable: false, identity: true),
                        DetalleSacramento = c.String(),
                        Ceremonia_CeremoniaID = c.Int(),
                        Matricula_MatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.SacramentoID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .ForeignKey("dbo.Matriculas", t => t.Matricula_MatriculaID)
                .Index(t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Matricula_MatriculaID);
            
            CreateTable(
                "dbo.Tipoceremonias",
                c => new
                    {
                        TipoceremoniaID = c.Int(nullable: false, identity: true),
                        Detalle = c.String(),
                        Costo = c.Int(nullable: false),
                        Ceremonia_CeremoniaID = c.Int(),
                    })
                .PrimaryKey(t => t.TipoceremoniaID)
                .ForeignKey("dbo.Ceremonias", t => t.Ceremonia_CeremoniaID)
                .Index(t => t.Ceremonia_CeremoniaID);
            
            CreateTable(
                "dbo.Directivas",
                c => new
                    {
                        DirectivaID = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        email = c.String(),
                        IglesiasId = c.Int(nullable: false),
                        CargosId = c.Int(nullable: false),
                        PeriodosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectivaID);
            
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        PeriodoID = c.Int(nullable: false, identity: true),
                        Detalle = c.String(),
                        Directiva_DirectivaID = c.Int(),
                        Matricula_MatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.PeriodoID)
                .ForeignKey("dbo.Directivas", t => t.Directiva_DirectivaID)
                .ForeignKey("dbo.Matriculas", t => t.Matricula_MatriculaID)
                .Index(t => t.Directiva_DirectivaID)
                .Index(t => t.Matricula_MatriculaID);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculaID = c.Int(nullable: false, identity: true),
                        IglesiasId = c.Int(nullable: false),
                        CatequistasId = c.Int(nullable: false),
                        SacramentosId = c.Int(nullable: false),
                        PeriodosId = c.Int(nullable: false),
                        MiembroMatricula_MiembroMatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.MatriculaID)
                .ForeignKey("dbo.MiembroMatriculas", t => t.MiembroMatricula_MiembroMatriculaID)
                .Index(t => t.MiembroMatricula_MiembroMatriculaID);
            
            CreateTable(
                "dbo.Miembroes",
                c => new
                    {
                        MiembroID = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Celular = c.String(),
                        Telefono = c.String(),
                        genero = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        email = c.String(),
                        MiembroCeremonia_MiembroCeremoniaID = c.Int(),
                        MiembroMatricula_MiembroMatriculaID = c.Int(),
                    })
                .PrimaryKey(t => t.MiembroID)
                .ForeignKey("dbo.MiembroCeremonias", t => t.MiembroCeremonia_MiembroCeremoniaID)
                .ForeignKey("dbo.MiembroMatriculas", t => t.MiembroMatricula_MiembroMatriculaID)
                .Index(t => t.MiembroCeremonia_MiembroCeremoniaID)
                .Index(t => t.MiembroMatricula_MiembroMatriculaID);
            
            CreateTable(
                "dbo.MiembroCeremonias",
                c => new
                    {
                        MiembroCeremoniaID = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        MiembrosId = c.Int(nullable: false),
                        CeremoniasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiembroCeremoniaID);
            
            CreateTable(
                "dbo.MiembroMatriculas",
                c => new
                    {
                        MiembroMatriculaID = c.Int(nullable: false, identity: true),
                        MiembrosId = c.Int(nullable: false),
                        MatriculasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiembroMatriculaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Miembroes", "MiembroMatricula_MiembroMatriculaID", "dbo.MiembroMatriculas");
            DropForeignKey("dbo.Matriculas", "MiembroMatricula_MiembroMatriculaID", "dbo.MiembroMatriculas");
            DropForeignKey("dbo.Miembroes", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropForeignKey("dbo.Ceremonias", "MiembroCeremonia_MiembroCeremoniaID", "dbo.MiembroCeremonias");
            DropForeignKey("dbo.Sacramentoes", "Matricula_MatriculaID", "dbo.Matriculas");
            DropForeignKey("dbo.Periodoes", "Matricula_MatriculaID", "dbo.Matriculas");
            DropForeignKey("dbo.Iglesias", "Matricula_MatriculaID", "dbo.Matriculas");
            DropForeignKey("dbo.Catequistas", "Matricula_MatriculaID", "dbo.Matriculas");
            DropForeignKey("dbo.Periodoes", "Directiva_DirectivaID", "dbo.Directivas");
            DropForeignKey("dbo.Iglesias", "Directiva_DirectivaID", "dbo.Directivas");
            DropForeignKey("dbo.Cargoes", "Directiva_DirectivaID", "dbo.Directivas");
            DropForeignKey("dbo.Tipoceremonias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Sacramentoes", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Sacerdotes", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Iglesias", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Horarios", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Facturas", "Ceremonia_CeremoniaID", "dbo.Ceremonias");
            DropForeignKey("dbo.Iglesias", "Catequista_CatequistaID", "dbo.Catequistas");
            DropForeignKey("dbo.Tipoiglesias", "Iglesia_IglesiaID", "dbo.Iglesias");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Miembroes", new[] { "MiembroMatricula_MiembroMatriculaID" });
            DropIndex("dbo.Miembroes", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            DropIndex("dbo.Matriculas", new[] { "MiembroMatricula_MiembroMatriculaID" });
            DropIndex("dbo.Periodoes", new[] { "Matricula_MatriculaID" });
            DropIndex("dbo.Periodoes", new[] { "Directiva_DirectivaID" });
            DropIndex("dbo.Tipoceremonias", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Sacramentoes", new[] { "Matricula_MatriculaID" });
            DropIndex("dbo.Sacramentoes", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Sacerdotes", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Horarios", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Facturas", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Ceremonias", new[] { "MiembroCeremonia_MiembroCeremoniaID" });
            DropIndex("dbo.Tipoiglesias", new[] { "Iglesia_IglesiaID" });
            DropIndex("dbo.Iglesias", new[] { "Matricula_MatriculaID" });
            DropIndex("dbo.Iglesias", new[] { "Directiva_DirectivaID" });
            DropIndex("dbo.Iglesias", new[] { "Ceremonia_CeremoniaID" });
            DropIndex("dbo.Iglesias", new[] { "Catequista_CatequistaID" });
            DropIndex("dbo.Catequistas", new[] { "Matricula_MatriculaID" });
            DropIndex("dbo.Cargoes", new[] { "Directiva_DirectivaID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MiembroMatriculas");
            DropTable("dbo.MiembroCeremonias");
            DropTable("dbo.Miembroes");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Periodoes");
            DropTable("dbo.Directivas");
            DropTable("dbo.Tipoceremonias");
            DropTable("dbo.Sacramentoes");
            DropTable("dbo.Sacerdotes");
            DropTable("dbo.Horarios");
            DropTable("dbo.Facturas");
            DropTable("dbo.Ceremonias");
            DropTable("dbo.Tipoiglesias");
            DropTable("dbo.Iglesias");
            DropTable("dbo.Catequistas");
            DropTable("dbo.Cargoes");
        }
    }
}
