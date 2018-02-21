using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Finaliglesia.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            userIdentity.AddClaim(new Claim("NombreCompleto", this.NombreCompleto));
            userIdentity.AddClaim(new Claim("Cedula", this.Cedula));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("cnn")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Tipoiglesia> TipoIglesias { get; set; }
        public DbSet<Sacerdote> Sacerdotes { get; set; }
        public DbSet<Tipoceremonia> TipoCeremonias { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Sacramento> Sacramentos { get; set; }
        public DbSet<Iglesia> Iglesias { get; set; }
        public DbSet<Catequista> Catequistas { get; set; }
        public DbSet<Directiva> Directivas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<MiembroMatricula> MiembrosMatriculas { get; set; }
        public DbSet<Ceremonia> Ceremonias { get; set; }
        public DbSet<MiembroCeremonia> MiembrosCeremonias { get; set; }
    }

}