using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

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
            _context.Services.Add(newService);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var service = GetByID(id);
            if (service != null)
            {
                service.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Service> GetAll()
        {
            var services = _context.Services.AsNoTracking().ToList();
            return services;
        }

        public Service GetByID(int id) => _context.Services.AsNoTracking().FirstOrDefault(s => s.Id == id);

        public List<ServiceInCategoryDto> GetCategoryServices(int id)
        {
            var services = _context.Services.AsNoTracking().Where(s => s.CategoryId == id)
                .Select(s => new ServiceInCategoryDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Category = s.Category.Title
                }).ToList();
            return services;
        }

        public bool Update(ServiceForUpdateDto serviceModel)
        {
            var service = GetByID(serviceModel.ServiceId);
            if (service != null)
            {
                service.Title = serviceModel.Title;
                service.IsDeleted= serviceModel.IsDeleted;
                service.CategoryId = serviceModel.CategoryId;
                _context.Update(service);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
