using App.Domain.Core.BidEntity.DTOs;

namespace App.Domain.Core.BidEntity.Contracts;

public interface IBidRepository
{
    public Task<bool> Create(CreateBidDto createBidDto, CancellationToken cancellationToken);
    public Task<bool> AcceptBid(int bidId, CancellationToken cancellationToken);
    public Task<Bid> GetById(int id, CancellationToken cancellationToken);
}
