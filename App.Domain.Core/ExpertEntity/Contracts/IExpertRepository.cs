namespace App.Domain.Core.ExpertEntity.Contracts
{
    public interface IExpertRepository
    {
        public Task<Expert> GetById(int id, CancellationToken cancellationToken);
        public Task<List<Expert>> GetAll(CancellationToken cancellationToken);
        public Task<bool> Register(Expert newExpert, CancellationToken cancellationToken);
    }
}
