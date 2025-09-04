using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.Entities.Entities.Address;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Document;
using NOTE.Solutions.Entities.Entities.Identity;
using NOTE.Solutions.Entities.Entities.Product;
using NOTE.Solutions.Entities.Entities.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.DAL.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
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
    public virtual DbSet<Tax> Taxes { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);
    }

}
