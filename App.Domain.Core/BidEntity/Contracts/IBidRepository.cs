namespace App.Domain.Core.BidEntity.Contracts
{
    public interface IBidRepository
    {
        public Task<bool> Create(Bid bid,CancellationToken cancellationToken);
        public Task <bool> IsAccepted(int id,CancellationToken cancellationToken);
        public Task <List<Bid>> GetForRequest(int RequestId,CancellationToken cancellationToken);
        public Task <Bid> GetById(int id,CancellationToken cancellationToken);
    }
}
