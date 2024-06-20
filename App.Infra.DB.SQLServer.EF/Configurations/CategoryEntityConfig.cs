﻿using App.Domain.Core.CategoryEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Categories");
            builder.HasData(
                new Category { Id = 1, Title = "دکوراسیون ساختمان" },
                new Category { Id = 2, Title = "تاسیسات ساختمان" },
                new Category { Id = 3, Title = "وسایل نقلیه" },
                new Category { Id = 4, Title = "اسباب کشی و باربری" },
                new Category { Id = 5, Title = "لوازم خانگی" },
                new Category { Id = 6, Title = "خدمات اداری" },
                new Category { Id = 7, Title = "خانه تکانی" },
                new Category { Id = 8, Title = "دیجیتال و نرم افزار" }
            );
        }
    }
}
