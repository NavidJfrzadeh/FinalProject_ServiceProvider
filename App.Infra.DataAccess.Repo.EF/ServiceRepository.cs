using App.Domain.Core.ServiceEntity;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ServiceRepository : IServiceRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memorycache;
        #endregion

        #region ctors
        public ServiceRepository(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memorycache = memoryCache;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(ServiceCreateDto newServiceModel, CancellationToken cancellationToken)
        {
            var newService = new Service()
            {
                Title = newServiceModel.Title,
                ImageSrc = newServiceModel.ImageSrc,
                BasePrice = newServiceModel.BasePrice,
                Description = newServiceModel.Description,
                CategoryId = newServiceModel.CategoryId
            };
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

        public async Task<List<ServiceListDto>> GetServiceList(CancellationToken cancellationToken)
        {
            var services = _memorycache.Get<List<ServiceListDto>>("ServiceList");
            if (services == null)
            {
                services = await _context.Services.AsNoTracking().Select(s => new ServiceListDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Category = s.Category.Title,
                    ExpertCount = s.Experts.Count(),
                    RequestCount = s.Requests.Count()
                }).ToListAsync(cancellationToken);
                _memorycache.Set("ServiceList", services, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(10)
                });
            }

            if (services.Any())
                return services;
            throw new Exception("خدماتی یافت نشد");
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

        public async Task<ServiceDetailsDto> GetDetails(int id, CancellationToken cancellationToken)
        {
            var serviceDto = await _context.Services.AsNoTracking().Where(s => s.Id == id)
                .Select(s => new ServiceDetailsDto
                {
                    ServiceId = s.Id,
                    Title = s.Title,
                    ImageSrc = s.ImageSrc,
                    BasePrice = s.BasePrice,
                    CategoryTitle = s.Category.Title,
                    Description = s.Description
                }).FirstOrDefaultAsync(cancellationToken);

            return serviceDto ?? throw new Exception($"service With Id {id} not found for service Details page");
        }

        public async Task<ServiceForUpdateDto> GetServiceForUpdate(int id, CancellationToken cancellationToken)
        {
            var service = await _context.Services.Where(s => s.Id == id)
                .Select(s => new ServiceForUpdateDto
                {
                    ServiceId = s.Id,
                    Title = s.Title,
                    BasePrice = s.BasePrice,
                    CategoryId = s.CategoryId,
                    Description = s.Description,
                    IsDeleted = s.IsDeleted,
                    ImageSrc = s.ImageSrc,
                }).FirstOrDefaultAsync(cancellationToken);

            return service ?? throw new Exception($"خدمت با آیدی{id} پیدا نشد");
        }

        public async Task<List<ServiceListDto>> GetCategoryServices(int id, CancellationToken cancellationToken)
        {

            var services = await _context.Services.AsNoTracking().Where(s => s.CategoryId == id)
            .Select(s => new ServiceListDto
            {
                Id = s.Id,
                Title = s.Title,
                Category = s.Category.Title,
                ExpertCount = s.Experts.Count(),
                RequestCount = s.Requests.Count()
            }).ToListAsync(cancellationToken);

            return services ?? throw new Exception("سرویسی یافت نشد");
        }

        public async Task<List<ServicesInCategory>> GetServicesInCategory(int CategoryId, CancellationToken cancellationToken)
        {
            var services = await _context.Services.AsNoTracking().Where(s => s.CategoryId == CategoryId)
                .Select(s => new ServicesInCategory
                {
                    Id = s.Id,
                    Title = s.Title,
                    CategoryTitle = s.Category.Title,
                    PictureLocation = s.ImageSrc
                }).ToListAsync(cancellationToken);

            return services ?? throw new Exception("خدماتی یافت نشد");

        }

        public async Task<bool> Update(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken)
        {
            var service = await FindById(serviceModel.ServiceId, cancellationToken);
            if (service != null)
            {
                service.Title = serviceModel.Title;
                service.IsDeleted = serviceModel.IsDeleted;
                service.CategoryId = serviceModel.CategoryId;
                service.BasePrice = serviceModel.BasePrice;
                service.Description = serviceModel.Description;
                serviceModel.ImageSrc = serviceModel.ImageSrc;
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
            return service ?? throw new Exception($"Service with Id {id} not found");
        }
        #endregion
    }
}
