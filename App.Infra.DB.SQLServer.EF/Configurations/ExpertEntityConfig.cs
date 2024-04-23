using App.Domain.Core.ExpertEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configurations
{
    public class ExpertEntityConfig : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.ToTable("Experts");
            builder.HasKey(x => x.Id);
            builder.HasMany(e => e.Comments)
                .WithOne(c => c.Expert)
                .HasForeignKey(c => c.ExpertId);
        }
    }
}
