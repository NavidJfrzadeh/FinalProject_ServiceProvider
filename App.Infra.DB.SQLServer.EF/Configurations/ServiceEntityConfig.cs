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
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Experts)
                .WithMany(e => e.Services);

            builder.HasMany(s => s.Requests)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Service() { Id = 1, Title = "بنایی و ساختمان", CategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 2, Title = "گچ کاری کاری", CategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 3, Title = "شیشه بری", CategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 4, Title = "کولر آبی", CategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 5, Title = "کولر گازی", CategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 6, Title = "آب گرم کن", CategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 7, Title = "لوله باز کنی", CategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 8, Title = "برق کاری ساختمان", CategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 9, Title = "تعویض روغن", CategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 10, Title = "نقاشی و صافکاری", CategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 11, Title = "تعمیر خودرو", CategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 12, Title = "اسباب کشی", CategoryId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 13, Title = "حمل بار جزعی", CategoryId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 14, Title = "یخچال و فریزر", CategoryId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 15, Title = "سینما خانگی", CategoryId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 16, Title = "ماشین لباس شویی", CategoryId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 17, Title = "فوتو کپی", CategoryId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 18, Title = "فکس", CategoryId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 19, Title = "پارتیشن", CategoryId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 20, Title = "نظافت منزل", CategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 21, Title = "نظافت اداره و شرکت", CategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 22, Title = "لپ تاپ و نوت بوک", CategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 23, Title = "موبایل و تبلت", CategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 24, Title = "ارتقای سخت افزاری", CategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                new Service() { Id = 25, Title = "شبکه کامپیوتری", CategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false }
                );
        }
    }
}
