using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;

namespace App.Domain.AppService;

public class RequestAppService : IRequestAppService
{
    #region Fields
    private readonly IRequestService _requestService;
    #endregion

    #region Ctors
    public RequestAppService(IRequestService requestService)
    {
        _requestService = requestService;
    }
    #endregion

    #region Implementations
    public async Task<bool> Accept(int id, CancellationToken cancellationToken)
        => await _requestService.Accept(id, cancellationToken);

    public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
        => await _requestService.Create(newRequestDto, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        => await _requestService.Delete(id, cancellationToken);

    public async Task<List<RequestDto>> GetAll(CancellationToken cancellationToken)
        => await _requestService.GetAll(cancellationToken);

    public async Task<Request> GetById(int id, CancellationToken cancellationToken)
        => await _requestService.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        => await _requestService.GetCustomerRequests(customerId, cancellationToken);

    public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        => await _requestService.GetForService(serviceId, cancellationToken);

    public async Task SetRequestStatus(int requestId, int? expertId, Status status, CancellationToken cancellationToken)
     => await _requestService.SetRequestStatus(requestId,expertId, status, cancellationToken);
    #endregion
}
