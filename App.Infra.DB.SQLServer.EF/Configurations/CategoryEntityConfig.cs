using App.Domain.Core.CategoryEntity;
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
                new Category { Id = 1, Title = "دکوراسیون ساختمان", PictureLocation = "\\assetsHomePage\\img\\categroy\\Architecture.png" },
                new Category { Id = 2, Title = "تاسیسات ساختمان", PictureLocation = "\\assetsHomePage\\img\\categroy\\repairing.png" },
                new Category { Id = 3, Title = "وسایل نقلیه", PictureLocation = "\\assetsHomePage\\img\\categroy\\cars.png" },
                new Category { Id = 4, Title = "اسباب کشی و باربری", PictureLocation = "\\assetsHomePage\\img\\categroy\\transport.png" },
                new Category { Id = 5, Title = "لوازم خانگی", PictureLocation = "\\assetsHomePage\\img\\categroy\\supplies.png" },
                new Category { Id = 6, Title = "خدمات اداری", PictureLocation = "\\assetsHomePage\\img\\categroy\\building.png" },
                new Category { Id = 7, Title = "خانه تکانی", PictureLocation = "\\assetsHomePage\\img\\categroy\\Cleaning.png" },
                new Category { Id = 8, Title = "دیجیتال و نرم افزار", PictureLocation = "\\assetsHomePage\\img\\categroy\\digital.png" }
            );
        }
    }
}
