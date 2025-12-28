using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class UserPermissionOverridesConfiguration : IEntityTypeConfiguration<UserPermissionOverride>
{
    public void Configure(EntityTypeBuilder<UserPermissionOverride> builder)
    {
        builder.HasKey(x => new { x.ApplicationUserId, x.RoleClaimId });

        builder.HasIndex(x => new { x.RoleClaimId, x.ApplicationUserId }).IsUnique();

        builder.HasOne(x => x.ApplicationUser)
               .WithMany(u => u.PermissionOverrides)
               .HasForeignKey(x => x.ApplicationUserId);

        builder.HasOne(x => x.RoleClaim)
               .WithMany()
               .HasForeignKey(x => x.RoleClaimId);
    }
}
