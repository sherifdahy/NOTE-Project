﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(x=> x.Name).IsUnique();

        builder.Property(x=>x.BranchId).IsRequired();

        builder
            .HasMany(x => x.ProductUnits)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x=>x.Branch)
            .WithMany(x => x.Products)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
