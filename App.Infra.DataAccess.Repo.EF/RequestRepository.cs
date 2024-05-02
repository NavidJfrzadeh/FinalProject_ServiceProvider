using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace App.Infra.DataAccess.Repo.EF
{
    public class RequestRepository : IRequestRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<bool> Accept(int id, CancellationToken cancellationToken)
        {
            var targetRequest = await FindById(id, cancellationToken);
            if (targetRequest != null)
            {
                targetRequest.IsAccepted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> Create(Request newRequest, CancellationToken cancellationToken)
        {
            await _context.Requests.AddAsync(newRequest, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var targetRequest = await FindById(id, cancellationToken);
            if (targetRequest != null)
            {
                targetRequest.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<List<Request>> GetAll(CancellationToken cancellationToken)
            => await _context.Requests.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Request> GetById(int id, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (request != null)
            {
                return request;
            }
            return new Request();
        }

        public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.AsNoTracking().Where(r => r.ServiceId == serviceId).ToListAsync(cancellationToken);
            return requests;
        }
        #endregion

        #region Private Methods
        private async Task<Request> FindById(int id, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(id, cancellationToken);
            if (request != null)
            {
                return request;
            }

            throw new Exception($"Request with Id {id} not found");
        }
        #endregion
    }
}
