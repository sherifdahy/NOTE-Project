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
            Id = DefaultRoles.AdminRoleId,
            Name = DefaultRoles.Admin,
            NormalizedName = DefaultRoles.Admin.ToUpper(),
            ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp,
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
