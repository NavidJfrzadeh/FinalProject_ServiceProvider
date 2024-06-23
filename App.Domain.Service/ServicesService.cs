using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.Service
{
    public class ServicesService : IServicesService
    {
        #region Fields
        private readonly IServiceRepository _serviceRepository;
        #endregion

        #region Ctors
        public ServicesService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(ServiceCreateDto newServiceModel, CancellationToken cancellationToken)
            => await _serviceRepository.Create(newServiceModel, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
            => await _serviceRepository.Delete(id, cancellationToken);

        public async Task<List<ServiceListForAdminDto>> GetServiceList(CancellationToken cancellationToken)
            => await _serviceRepository.GetServiceList(cancellationToken);

        public async Task<Core.ServiceEntity.Service> GetById(int id, CancellationToken cancellationToken)
            => await _serviceRepository.GetById(id, cancellationToken);

        public async Task<ServiceForUpdateDto> GetServiceForUpdate(int id, CancellationToken cancellationToken)
            => await _serviceRepository.GetServiceForUpdate(id, cancellationToken);

        public async Task<List<ServiceListForAdminDto>> GetCategoryServices(int id, CancellationToken cancellationToken)
            => await _serviceRepository.GetCategoryServices(id, cancellationToken);

        public async Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken)
            => await _serviceRepository.Update(serviceModel, cancellationToken);

        public async Task<List<ServiceListDto>> GetServicesInCategory(int CategoryId, CancellationToken cancellationToken)
            => await _serviceRepository.GetServicesInCategory(CategoryId, cancellationToken);

        public async Task<ServiceDetailsDto> GetDetails(int id, CancellationToken cancellationToken)
            => await _serviceRepository.GetDetails(id, cancellationToken);

        public async Task<List<ServiceListDto>> Search(string name, CancellationToken cancellationToken)
            => await _serviceRepository.Search(name, cancellationToken);
        #endregion
    }
}
