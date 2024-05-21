using App.Domain.Core.AdminEntity;
using App.Domain.Core.AdminEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        public Admin GetById(int id) => _context.Admins.AsNoTracking().FirstOrDefault(a => a.Id == id);
    }
}
