using App.Domain.Core.CustomerEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class CustomerEntityConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Requests)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(cu => cu.Comments)
                .WithOne(co => co.Customer)
                .HasForeignKey(co => co.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(cu=>cu.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a=>a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
