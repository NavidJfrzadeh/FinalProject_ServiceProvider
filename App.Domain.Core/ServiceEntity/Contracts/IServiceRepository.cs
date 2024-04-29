using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.Core.ServiceEntity.Contracts
{
    public interface IServiceRepository
    {
        public Service GetByID(int id);
        public List<Service> GetAll();
        public List<ServiceInCategoryDto> GetCategoryServices(int id);
        public bool Create(Service newService);
        public bool Delete(int id);
        public bool Update(ServiceForUpdateDto serviceModel);
    }
}
