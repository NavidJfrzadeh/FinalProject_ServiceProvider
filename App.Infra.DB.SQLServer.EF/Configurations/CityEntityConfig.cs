using App.Domain.Core._0_BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class CityEntityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasData(
                new City { Id = 1, Name = "Teharn" },
                new City { Id = 2, Name = "Tabriz" },
                new City { Id = 3, Name = "Shiraz" },
                new City { Id = 4, Name = "Ahvaz" },
                new City { Id = 5, Name = "Arak" },
                new City { Id = 6, Name = "Qazvin" }
                );
        }
    }
}