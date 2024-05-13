using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.Core.ServiceEntity.Contracts;

public interface IServicesAppService
{
    public Task<Service> GetById(int id, CancellationToken cancellationToken);
    public Task<List<ServiceListDto>> GetServiceList(CancellationToken cancellationToken);
    public Task<List<ServiceListDto>> GetCategoryServices(int id, CancellationToken cancellationToken);
    public Task<bool> Create(ServiceCreateDto newServiceModel, CancellationToken cancellationToken);
    public Task<bool> Delete(int id, CancellationToken cancellationToken);
    public Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken);
}
