using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;
public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(new ApplicationRole()
        {
            Id = DefaultRoles.SystemAdminRoleId,
            Name = DefaultRoles.SystemAdmin,
            IsDefault = false,
            NormalizedName = DefaultRoles.SystemAdmin.ToUpper(),
            ConcurrencyStamp = DefaultRoles.SystemAdminRoleConcurrencyStamp,
        },
        new ApplicationRole()
        {
            Id = DefaultRoles.MemberRoleId,
            IsDefault = true,
            Name = DefaultRoles.Member,
            NormalizedName= DefaultRoles.Member.ToUpper(),
            ConcurrencyStamp= DefaultRoles.MemberRoleConcurrencyStamp
        });
    }
}
