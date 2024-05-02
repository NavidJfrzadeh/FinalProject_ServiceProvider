using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ServiceRepository : IServiceRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctors
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(Service newService, CancellationToken cancellationToken)
        {
            await _context.Services.AddAsync(newService, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var service = await FindById(id, cancellationToken);
            if (service != null)
            {
                service.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<List<Service>> GetAll(CancellationToken cancellationToken)
        {
            var services = await _context.Services.AsNoTracking().ToListAsync(cancellationToken);
            return services;
        }

        public async Task<Service> GetById(int id, CancellationToken cancellationToken)
        {
            var service = await _context.Services.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (service != null)
            {
                return service;
            }
            return new Service();
        }

        public async Task<List<ServiceInCategoryDto>> GetCategoryServices(int id, CancellationToken cancellationToken)
        {
            var services = await _context.Services.AsNoTracking().AsNoTracking().Where(s => s.CategoryId == id)
                .Select(s => new ServiceInCategoryDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Category = s.Category.Title
                }).ToListAsync(cancellationToken);
            return services;
        }

        public async Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken)
        {
            var service = await FindById(serviceModel.ServiceId, cancellationToken);
            if (service != null)
            {
                service.Title = serviceModel.Title;
                service.IsDeleted = serviceModel.IsDeleted;
                service.CategoryId = serviceModel.CategoryId;
                _context.Update(service);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion

        #region Private Methods
        private async Task<Service> FindById(int id, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(id, cancellationToken);
            if (service != null)
            {
                return service;
            }
            throw new Exception($"Service with Id {id} not found");
        }
        #endregion
    }
}
