using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Infra.DB.SQLServer.EF;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Service newService)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var service = GetByID(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Service> GetAll()
        {
            var services = _context.Services.ToList();
            return services;
        }

        public Service GetByID(int id) => _context.Services.FirstOrDefault(s=>s.Id == id);

        public bool Update(Service serviceModel)
        {
            throw new NotImplementedException();
        }
    }
}
