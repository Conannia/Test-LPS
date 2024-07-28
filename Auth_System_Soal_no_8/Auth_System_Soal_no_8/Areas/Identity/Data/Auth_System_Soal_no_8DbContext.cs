using Auth_System_Soal_no_8.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth_System_Soal_no_8.Data;

public class Auth_System_Soal_no_8DbContext : IdentityDbContext<Auth_System_Soal_no_8User>
{
    public Auth_System_Soal_no_8DbContext(DbContextOptions<Auth_System_Soal_no_8DbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
