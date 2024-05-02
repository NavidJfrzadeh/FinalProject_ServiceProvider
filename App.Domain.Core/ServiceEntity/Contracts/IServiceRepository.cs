using App.Domain.Core.ServiceEntity.DTOs;
using System.Threading;

namespace App.Domain.Core.ServiceEntity.Contracts
{
    public interface IServiceRepository
    {
        public Task<Service> GetById(int id, CancellationToken cancellationToken);
        public Task<List<Service>> GetAll(CancellationToken cancellationToken);
        public Task<List<ServiceInCategoryDto>> GetCategoryServices(int id, CancellationToken cancellationToken);
        public Task<bool> Create(Service newService, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken);
    }
}
