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
    public async Task<bool> Create(Bid bid, CancellationToken cancellationToken)
        => await _bidRepository.Create(bid, cancellationToken);

    public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        => await _bidRepository.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestBidsDto>> GetForRequest(int RequestId, CancellationToken cancellationToken)
        => await _bidRepository.GetForRequest(RequestId, cancellationToken);

    public async Task<bool> IsAccepted(int id, CancellationToken cancellationToken)
        => await _bidRepository.IsAccepted(id, cancellationToken);
    #endregion
}
