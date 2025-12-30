using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {
        builder.HasData(new IdentityUserRole<int>()
        {
            RoleId = DefaultRoles.SystemAdminRoleId,
            UserId = DefaultUsers.SystemAdminId,
        });
    }
}
