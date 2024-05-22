using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.AppService
{
    public class ServicesAppService : IServicesAppService
    {
        #region Fields
        private readonly IServicesService _servicesService;
        #endregion

        #region Ctors
        public ServicesAppService(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        #endregion

        #region Implementations
        public Task<bool> Create(ServiceCreateDto newServiceModel, CancellationToken cancellationToken)
            => _servicesService.Create(newServiceModel, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
            => await _servicesService.Delete(id, cancellationToken);

        public Task<List<ServiceListDto>> GetServiceList(CancellationToken cancellationToken)
            => _servicesService.GetServiceList(cancellationToken);

        public async Task<Service> GetById(int id, CancellationToken cancellationToken)
            => await _servicesService.GetById(id, cancellationToken);

        public async Task<ServiceForUpdateDto> GetServiceForUpdate(int id, CancellationToken cancellationToken)
            => await _servicesService.GetServiceForUpdate(id, cancellationToken);

        public async Task<List<ServiceListDto>> GetCategoryServices(int id, CancellationToken cancellationToken)
            => await _servicesService.GetCategoryServices(id, cancellationToken);

        public async Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken)
            => await _servicesService.Update(serviceModel, cancellationToken);

        public async Task<List<ServicesInCategory>> GetServicesInCategory(int CategoryId, CancellationToken cancellationToken)
            => await _servicesService.GetServicesInCategory(CategoryId, cancellationToken);

        public async Task<ServiceDetailsDto> GetDetails(int id, CancellationToken cancellationToken)
            => await _servicesService.GetDetails(id, cancellationToken);
        #endregion
    }
}
