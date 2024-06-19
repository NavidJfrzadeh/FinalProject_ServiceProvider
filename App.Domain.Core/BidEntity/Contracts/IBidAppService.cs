using App.Domain.Core.BidEntity.DTOs;

namespace App.Domain.Core.BidEntity.Contracts;

public interface IBidAppService
{
    public Task<bool> Create(CreateBidDto createBidDto, CancellationToken cancellationToken);
    public Task<bool> AssignBid(int bidId, int requestId, int expertId, CancellationToken cancellationToken);
    public Task<Bid> GetById(int id, CancellationToken cancellationToken);
}
