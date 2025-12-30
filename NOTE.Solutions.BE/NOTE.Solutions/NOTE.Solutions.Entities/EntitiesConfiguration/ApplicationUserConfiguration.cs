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
            Id = DefaultUsers.SystemAdminId,
            UserName = DefaultUsers.SystemAdminEmail,
            Email = DefaultUsers.SystemAdminEmail,
            NormalizedEmail = DefaultUsers.SystemAdminEmail.ToUpper(),
            NormalizedUserName = DefaultUsers.SystemAdminEmail.ToUpper(),
            ConcurrencyStamp = DefaultUsers.SystemAdminConcurrencyStamp,
            SecurityStamp = DefaultUsers.SystemAdminSecurityStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.SystemAdminPassword
        });
    }
}
