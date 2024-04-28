using App.Domain.Core.RequestEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class RequestEntityConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasMany(r => r.Bids)
                .WithOne(b => b.Request)
                .HasForeignKey(b => b.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
