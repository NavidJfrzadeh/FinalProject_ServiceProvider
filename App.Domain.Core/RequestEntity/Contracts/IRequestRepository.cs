namespace App.Domain.Core.RequestEntity.Contracts
{
    public interface IRequestRepository
    {
        public Task< bool> Create(Request newRequest, CancellationToken cancellationToken);
        public Task<Request> GetById(int id, CancellationToken cancellationToken);
        public Task<List<Request>> GetAll(CancellationToken cancellationToken);
        public Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken);
        public Task<bool> Accept(int id, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
