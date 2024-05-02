using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ExpertRepository : IExpertRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctors
        public ExpertRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        {
            var Experts = await _context.Experts.AsNoTracking().ToListAsync(cancellationToken);
            if (Experts.Any())
            {
                return Experts;
            }
            return new List<Expert>();
        }

        public async Task<Expert> GetById(int id, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (expert != null)
            {
                return expert;
            }
            return new Expert();
        }

        public async Task<bool> Register(Expert newExpert, CancellationToken cancellationToken)
        {
            await _context.Experts.AddAsync(newExpert, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion

        #region Private methods
        private async Task<Expert> FindById(int id, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.FindAsync(id, cancellationToken);
            if (expert != null)
            {
                return expert;
            }
            throw new Exception($"Expert with Id {id} not found");
        }
        #endregion
    }
}
