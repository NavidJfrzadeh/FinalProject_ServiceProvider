using App.Domain.Core.CommentEntity;
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

            builder.HasOne(r => r.AcceptedExpert)
                .WithMany(e => e.AcceptedRequests)
                .HasForeignKey(r => r.AcceptedExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Comment)
                .WithOne(c => c.Request)
                .HasForeignKey<Request>(r => r.CommentId);
        }
    }
}
