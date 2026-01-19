using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Abstractions.Consts;
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ApplicationUserContextsConfiguration : IEntityTypeConfiguration<ApplicationUserContexts>
{
    public void Configure(EntityTypeBuilder<ApplicationUserContexts> builder)
    {
        builder.HasKey(x => new { x.ContextId, x.ApplicationUserId });

        builder.HasData(new ApplicationUserContexts()
        {
            ApplicationUserId = DefaultUsers.SystemAdminId,
            ContextId = DefaultContext.SystemAdminId
        });
    }
}
