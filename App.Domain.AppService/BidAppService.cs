using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;
using Framework;

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
    public async Task<bool> Create(CreateBidDto createBidDto, CancellationToken cancellationToken)
    {
        var dateFor = createBidDto.PersianDate.ConvertToGregorian();
        createBidDto.DateFor = dateFor;
        return await _bidService.Create(createBidDto, cancellationToken);
    }

    public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        => await _bidService.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestBidsDto>> GetForRequest(int RequestId, CancellationToken cancellationToken)
        => await _bidService.GetForRequest(RequestId, cancellationToken);

    public async Task<bool> AcceptBid(int bidId, CancellationToken cancellationToken)
        => await _bidService.AcceptBid(bidId, cancellationToken);
    #endregion
}
