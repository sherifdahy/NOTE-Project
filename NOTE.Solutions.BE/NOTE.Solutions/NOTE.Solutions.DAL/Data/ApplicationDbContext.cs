using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.API.Extensions;
using NOTE.Solutions.Entities.Entities;
using NOTE.Solutions.Entities.Entities.Address;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Document;
using NOTE.Solutions.Entities.Entities.Identity;
using NOTE.Solutions.Entities.Entities.Product;
using NOTE.Solutions.Entities.Entities.Unit;
using NOTE.Solutions.Entities.Extensions;
using System.Security.Claims;

namespace NOTE.Solutions.DAL.Data;
public class ApplicationDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContext;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions,IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
    {
        _httpContext = httpContextAccessor;
    }

    #region Identity
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
    #endregion

    #region Address
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Governorate> Governorates { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    #endregion

    #region Company
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<ActiveCode> ActiveCodes { get; set; }
    public virtual DbSet<Branch> Branches { get; set; }
    #endregion

    #region Product
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductUnit> ProductUnits { get; set; }
    public virtual DbSet<Unit> Units { get; set; }
    #endregion

    #region Document
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }
    public virtual DbSet<DocumentTax> Taxes { get; set; }
    public virtual DbSet<DocumentDiscount> Discounts { get; set; }
    public virtual DbSet<POS> POSs { get; set; }

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();

        modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            .ToList()
            .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();

        if(entries.Any())
        {
            var currentUserId = _httpContext.HttpContext.User.GetUserId();
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x => x.CreatedById).CurrentValue = currentUserId;
                    entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x => x.UpdatedById).CurrentValue = currentUserId;
                    entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;

                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
