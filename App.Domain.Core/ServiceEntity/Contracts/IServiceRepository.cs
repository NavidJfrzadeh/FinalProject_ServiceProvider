namespace App.Domain.Core.ServiceEntity.Contracts
{
    public interface IServiceRepository
    {
        public Service GetByID(int id);
        public List<Service> GetAll();
        public bool Create(Service newService);
        public bool Delete(int id);
        public bool Update(Service serviceModel);
    }
}
