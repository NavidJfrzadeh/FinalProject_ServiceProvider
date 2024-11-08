﻿using App.Domain.Core.AdminEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class AdminEntityConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FistName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.HasOne(a => a.ApplicationUser)
                .WithOne(ap => ap.Admin);

            builder.HasData(
                new Admin { Id = 1, FistName = "Navid", LastName = "Jafarzadeh", FullName = "Navid Jafarzadeh", ApplicationUserId = 1 }
                );
        }
    }
}
