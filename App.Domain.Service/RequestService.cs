using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;

namespace App.Domain.Service;

public class RequestService : IRequestService
{
    #region Fields
    private readonly IRequestRepository _requestRepository;
    #endregion

    #region Ctors
    public RequestService(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }
    #endregion

    #region Implementations
    public async Task<bool> Accept(int id, CancellationToken cancellationToken)
        => await _requestRepository.Accept(id, cancellationToken);

    public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
        => await _requestRepository.Create(newRequestDto, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        => await _requestRepository.Delete(id, cancellationToken);

    public async Task<List<RequestDto>> GetAll(CancellationToken cancellationToken)
        => await _requestRepository.GetAll(cancellationToken);

    public async Task<Request> GetById(int id, CancellationToken cancellationToken)
        => await _requestRepository.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        => await _requestRepository.GetCustomerRequests(customerId, cancellationToken);

    public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        => await _requestRepository.GetForService(serviceId, cancellationToken);

    public Task SetRequestStatus(int requestId, int? expertId, Status status, CancellationToken cancellationToken)
        => _requestRepository.SetRequestStatus(requestId, expertId, status, cancellationToken);
    #endregion
}
