using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;
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

        public Service GetByID(int id) => _context.Services.FirstOrDefault(s => s.Id == id);

        public List<ServiceInCategoryDto> GetCategoryServices(int id)
        {
            var services = _context.Services.Where(s => s.CategoryId == id)
                .Select(s => new ServiceInCategoryDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Category = s.Category.Title
                }).ToList();
            return services;
        }

        public bool Update(Service serviceModel)
        {
            throw new NotImplementedException();
        }
    }
}
