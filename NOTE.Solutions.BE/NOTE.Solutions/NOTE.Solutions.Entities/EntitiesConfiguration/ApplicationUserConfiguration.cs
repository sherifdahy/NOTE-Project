using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;
namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasIndex(x => new { x.Email }).IsUnique();

        builder.OwnsMany(x => x.RefreshTokens).WithOwner();



        builder.HasData(new ApplicationUser()
        {
            Id = DefaultUsers.AdminId,
            UserName = DefaultUsers.AdminEmail,
            Email = DefaultUsers.AdminEmail,
            NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
            NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
            ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
            SecurityStamp = DefaultUsers.AdminSecurityStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.AdminPassword
        },
        new ApplicationUser()
        {
            Id = DefaultUsers.SupportId,
            UserName = DefaultUsers.SupportEmail,
            Email = DefaultUsers.SupportEmail,
            NormalizedEmail = DefaultUsers.SupportEmail.ToUpper(),
            NormalizedUserName = DefaultUsers.SupportEmail.ToUpper(),
            ConcurrencyStamp = DefaultUsers.SupportConcurrencyStamp,
            SecurityStamp = DefaultUsers.SupportSecurityStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.AdminPassword
        });
    }
}
