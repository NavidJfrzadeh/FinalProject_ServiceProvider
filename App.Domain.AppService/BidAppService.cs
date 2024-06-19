using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;
using Framework;

namespace App.Domain.AppService;

public class BidAppService : IBidAppService
{
    #region Fields
    private readonly IBidService _bidService;
    private readonly IRequestService _requestService;
    #endregion

    #region Ctors
    public BidAppService(IBidService bidService, IRequestService requestService)
    {
        _bidService = bidService;
        _requestService = requestService;
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

    public async Task<bool> AssignBid(int bidId, int requestId, int expertId, CancellationToken cancellationToken)
    {
        var result = await _bidService.AcceptBid(bidId, cancellationToken);
        if (result)
        {
            await _requestService.SetExpert(requestId, expertId, cancellationToken);
            return true;
        }
        return false;
    }
    #endregion
}
