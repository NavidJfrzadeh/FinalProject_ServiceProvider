using App.Domain.Core.ServiceEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class ServiceEntityConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
            builder.HasOne(s => s.Category)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CategoryId);
            builder.HasMany(s => s.Experts)
                .WithMany(e => e.Services);
            builder.HasMany(s => s.Requests)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId);
        }
    }
}
