using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SUDO.Models;

namespace SUDO.Areas.Identity.Data;

public class SUDOIdentityDbContext : IdentityDbContext<ApplicationUser>
{

    public SUDOIdentityDbContext(DbContextOptions<SUDOIdentityDbContext> options) : base(options) {}
    public DbSet<Offer> Offer {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    
    }
}
