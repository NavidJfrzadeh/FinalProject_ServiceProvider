namespace App.Domain.Core.BidEntity.Contracts
{
    public interface IBidRepository
    {
        public bool Create(Bid bid);
        public bool IsAccepted(int id);
        public List<Bid> GetForRequest(int RequestId);
        public Bid GetById(int id);
    }
}
