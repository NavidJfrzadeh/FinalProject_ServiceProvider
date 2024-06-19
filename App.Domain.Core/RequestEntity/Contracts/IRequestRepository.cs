using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity.DTOs;

namespace App.Domain.Core.RequestEntity.Contracts;

public interface IRequestRepository
{
    public Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken);
    public Task<RequestDetailsDto> GetById(int requestId, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetAll(CancellationToken cancellationToken);
    public Task<int> GetRequestsCount(CancellationToken cancellationToken);
    public Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken);
    public Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken);
    public Task<bool> Accept(int requestId, CancellationToken cancellationToken);
    public Task<bool> Reject(int requestId, CancellationToken cancellationToken);
    public Task<bool> Delete(int requestId, CancellationToken cancellationToken);
    public Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetRequestsForExpert(List<int> categoryIds, int expertId, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetFinishedReqeustsForExpert(int expertId, CancellationToken cancellationToken);
    public Task<List<CustomerRequestDto>> GetFinishedRequestsForCustomer(int customerId, CancellationToken cancellationToken);
    public Task SetExpert(int requestId, int expertId, CancellationToken cancellationToken);
    public Task SetComment(int requestId, int commentId, CancellationToken cancellationToken);
}
