using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;

namespace App.Domain.Service;

public class BidService : IBidService
{
    #region Fields
    private readonly IBidRepository _bidRepository;
    #endregion

    #region Ctors
    public BidService(IBidRepository bidRepository)
    {
        _bidRepository = bidRepository;
    }
    #endregion


    #region Implementations
    public async Task<bool> Create(CreateBidDto createBidDto, CancellationToken cancellationToken)
        => await _bidRepository.Create(createBidDto, cancellationToken);

    public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        => await _bidRepository.GetById(id, cancellationToken);

    public async Task<bool> AcceptBid(int BidId, CancellationToken cancellationToken)
        => await _bidRepository.AcceptBid(BidId, cancellationToken);
    #endregion
}
