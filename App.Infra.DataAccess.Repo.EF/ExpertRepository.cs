using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _context;

        public ExpertRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Expert> GetAll()
        {
            var Experts = _context.Experts.AsNoTracking().ToList();
            if (Experts.Any())
            {
                return Experts;
            }
            return null;
        }

        public Expert GetById(int id) => _context.Experts.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public bool Register(Expert newExpert)
        {
            _context.Experts.Add(newExpert);
            _context.SaveChanges();
            return true;
        }
    }
}
