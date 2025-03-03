using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "b1ea5f0b-9d02-4274-9ec4-653266d741a4",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole
            {
                Id = "51ebf45e-e394-4f00-84d5-9723848f60f3",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            },
            new IdentityRole 
            { 
                Id = "f9565a3f-fe93-4fac-9ec9-772c0f1c7289",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
           );
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
        {
                 Id = "839179df-57df-40f3-b88c-489024651b60",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 UserName = "admin@localhost.com",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true,
                 FirstName = "Default",
                 LastName = "Admin",
                 DateOfBirth = new DateOnly(1950,12,01)
             });

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string >
            {
                RoleId = "f9565a3f-fe93-4fac-9ec9-772c0f1c7289",
                UserId = "839179df-57df-40f3-b88c-489024651b60"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
}
