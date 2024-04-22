using App.Domain.Core._0_BaseEntity;
using App.Domain.Core.AdminEntity;
using App.Domain.Core.BidEntity;
using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CommentEntity;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.ServiceEntity;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        //gender
        //status
        //Status Values attrib
    }
}
