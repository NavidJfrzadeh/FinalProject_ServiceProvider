using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity.DTOs;

namespace App.Domain.Core.RequestEntity.Contracts
{
    public interface IRequestAppService
    {
        public Task<bool> Create(Request newRequest, CancellationToken cancellationToken);
        public Task<Request> GetById(int id, CancellationToken cancellationToken);
        public Task<List<RequestDto>> GetAll(CancellationToken cancellationToken);
        public Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken);
        public Task<bool> Accept(int id, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken);
    }
}
