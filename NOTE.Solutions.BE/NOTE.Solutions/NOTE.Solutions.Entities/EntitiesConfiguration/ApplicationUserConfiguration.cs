using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Identity;
namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.HasIndex(x => new { x.Email });

        builder
            .HasMany(x => x.Branches)
            .WithMany(x => x.ApplicationUsers);


        builder
            .HasOne(x => x.ApplicationRole)
            .WithMany(x => x.ApplicationUsers).HasForeignKey(x=>x.ApplicationRoleId).OnDelete(DeleteBehavior.Restrict);

    }
}
