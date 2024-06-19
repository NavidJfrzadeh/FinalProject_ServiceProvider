using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity.DTOs;

namespace App.Domain.Core.RequestEntity.Contracts;

public interface IRequestAppService
{
    public Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken);
    public Task<RequestDetailsDto> GetById(int id, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetAll(CancellationToken cancellationToken);
    public Task<int> GetRequestsCount(CancellationToken cancellationToken);
    public Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken);
    public Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken);
    public Task<bool> Accept(int requestId, Status status, CancellationToken cancellationToken);
    public Task Reject(int requestId, Status status, CancellationToken cancellationToken);
    public Task<bool> Delete(int id, CancellationToken cancellationToken);
    public Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetRequestsForExpert(int expertId, CancellationToken cancellationToken);
    public Task<List<RequestDto>> GetFinishedReqeustsForExpert(int expertId, CancellationToken cancellationToken);
    public Task<List<CustomerRequestDto>> GetFinishedRequestsForCustomer(int customerId, CancellationToken cancellationToken);
}
