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

    public async Task<bool> Reject(int requestId, CancellationToken cancellationToken)
        => await _requestRepository.Reject(requestId, cancellationToken);

    public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
        => await _requestRepository.Create(newRequestDto, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        => await _requestRepository.Delete(id, cancellationToken);

    public async Task<List<RequestDto>> GetAll(CancellationToken cancellationToken)
        => await _requestRepository.GetAll(cancellationToken);

    public async Task<RequestDetailsDto> GetById(int id, CancellationToken cancellationToken)
        => await _requestRepository.GetById(id, cancellationToken);

    public async Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        => await _requestRepository.GetCustomerRequests(customerId, cancellationToken);

    public async Task<List<RequestDto>> GetRequestsForExpert(List<int> categoryIds, int expertId, CancellationToken cancellationToken)
        => await _requestRepository.GetRequestsForExpert(categoryIds, expertId, cancellationToken);

    public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        => await _requestRepository.GetForService(serviceId, cancellationToken);

    public async Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken)
        => await _requestRepository.SetRequestStatus(requestId, status, cancellationToken);

    public async Task<List<RequestDto>> GetFinishedReqeustsForExpert(int expertId, CancellationToken cancellationToken)
         => await _requestRepository.GetFinishedReqeustsForExpert(expertId, cancellationToken);

    public async Task<int> GetRequestsCount(CancellationToken cancellationToken)
        => await _requestRepository.GetRequestsCount(cancellationToken);

    public async Task SetExpert(int requestId, int expertId, CancellationToken cancellationToken)
        => await _requestRepository.SetExpert(requestId, expertId, cancellationToken);

    public async Task<List<CustomerRequestDto>> GetFinishedRequestsForCustomer(int customerId, CancellationToken cancellationToken)
        => await _requestRepository.GetFinishedRequestsForCustomer(customerId, cancellationToken);

    public async Task SetComment(int requestId, int commentId, CancellationToken cancellationToken)
        => await _requestRepository.SetComment(requestId, commentId, cancellationToken);
    #endregion
}
