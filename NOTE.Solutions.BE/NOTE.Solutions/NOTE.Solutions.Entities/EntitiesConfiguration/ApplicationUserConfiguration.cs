using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Identity;
namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.HasIndex(x => new { x.Email });

        builder.HasData(new ApplicationUser()
        {
            Id = 1,
            ApplicationRoleId = 1,
            Email = "admin@gmail.com",
            Password = "333Sherif%",
            Name = "Sherif Dahy",
            SSN = "30011122102153",
            PhoneNumber = "01014133874",
        });

    }
}
