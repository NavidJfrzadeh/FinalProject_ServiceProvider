using App.Domain.Core.Enums;
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
            builder.Property(e => e.Score).HasPrecision(18, 1);
            builder.HasMany(e => e.Comments)
                .WithOne(c => c.Expert)
                .HasForeignKey(c => c.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Services)
                .WithMany(s => s.Experts);

            builder.HasMany(e => e.Bids)
                .WithOne(b => b.Expert)
                .HasForeignKey(b => b.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ApplicationUser)
                .WithOne(ap => ap.Expert);

            builder.HasData(
                new Expert { Id = 2, FirstName = "Ali", LastName = "Karimi", FullName = "Ali Karimi", Gender = Gender.Male, ApplicationUserId = 2 },
                new Expert { Id = 3, FirstName = "Sahar", LastName = "Akbari", FullName = "Sahar Akbari", Gender = Gender.Female, ApplicationUserId = 3 }
                );
        }
    }
}
