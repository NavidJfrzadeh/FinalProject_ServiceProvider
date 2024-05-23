using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;

namespace App.Domain.AppService;

public class BidAppService : IBidAppService
{
    #region Fields
    private readonly IBidService _bidService;
    #endregion

    #region Ctors
    public BidAppService(IBidService bidService)
    {
        _bidService = bidService;
    }
    #endregion

    #region Implementations
    public async Task<bool> Create(Bid bid, CancellationToken cancellationToken)
     => await _bidService.Create(bid, cancellationToken);

    public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        => await _bidService.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestBidsDto>> GetForRequest(int RequestId, CancellationToken cancellationToken)
        => await _bidService.GetForRequest(RequestId, cancellationToken);

    public async Task<bool> IsAccepted(int id, CancellationToken cancellationToken)
        => await _bidService.IsAccepted(id, cancellationToken);
    #endregion
}
