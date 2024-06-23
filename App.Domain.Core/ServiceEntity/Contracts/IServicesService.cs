using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.Core.ServiceEntity.Contracts;

public interface IServicesService
{
    public Task<Service> GetById(int id, CancellationToken cancellationToken);
    public Task<ServiceDetailsDto> GetDetails(int id, CancellationToken cancellationToken);
    public Task<ServiceForUpdateDto> GetServiceForUpdate(int id, CancellationToken cancellationToken);
    public Task<List<ServiceListForAdminDto>> GetServiceList(CancellationToken cancellationToken);
    public Task<List<ServiceListForAdminDto>> GetCategoryServices(int id, CancellationToken cancellationToken);
    public Task<List<ServiceListDto>> GetServicesInCategory(int CategoryId, CancellationToken cancellationToken);
    public Task<bool> Create(ServiceCreateDto newServiceModel, CancellationToken cancellationToken);
    public Task<bool> Delete(int id, CancellationToken cancellationToken);
    public Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken);
    public Task<List<ServiceListDto>> Search(string name, CancellationToken cancellationToken);
}

