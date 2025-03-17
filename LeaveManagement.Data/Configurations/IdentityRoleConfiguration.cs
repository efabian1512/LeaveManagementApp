using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
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
        }
    }
}
