using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Domain.Core.ServiceEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;
        private readonly IMemoryCache _memoryCache;
        #endregion

        #region Ctors
        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger, IMemoryCache memoryCache)
        {
            _context = context;
            _logger = logger;
            _memoryCache = memoryCache;
        }
        #endregion

        #region Implementations
        public async Task<List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var Categories = _memoryCache.Get<List<GetAllCategoryForMainPageDto>>("Categories");
                if (Categories == null)
                {
                    Categories = await _context.Categories.AsNoTracking().Where(c => !c.IsDeleted).Select(c => new GetAllCategoryForMainPageDto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        CountService = c.Services.Count()
                    }).ToListAsync(cancellationToken);
                    _memoryCache.Set("Categories", Categories, new MemoryCacheEntryOptions()
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                return Categories;
            }
            catch (Exception ex)
            {
                throw new Exception("دسته بندی ای پیدا نشد" + ex.Message);
            }

        }

        public async Task<List<CategoryDto>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = _memoryCache.Get<List<CategoryDto>>("CategoriesForCreateServiceDto");
            if (categories == null)
            {
                categories = await _context.Categories.AsNoTracking().Select(c => new CategoryDto
                {
                    CategoyId = c.Id,
                    Title = c.Title
                }).ToListAsync(cancellationToken);
                _memoryCache.Set("CategoriesForCreateServiceDto", categories, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                });
            }
            if (categories.Any())
            {
                return categories;
            }
            throw new Exception("دسته بندی یافت نشد");
        }

        public async Task Create(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = new Category
                {
                    Title = CategoryTitle,
                    PictureLocation = CategoryPicture
                };
                await _context.Categories.AddAsync(newCategory, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"دسته بندی جدیدی با آیدی{newCategory.Id} و عنوان{newCategory.Title} ذخیره شد");
            }
            catch (Exception ex)
            {
                throw new Exception("ساخت دسته بندی جدید ناموفق بود" + ex.Message);
            }
        }

        public async Task Update(int id, string Title, CancellationToken cancellationToken)
        {
            var category = await FindCategory(id, cancellationToken);
            if (category != null)
            {
                category.Title = Title;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("دسته بندی ویرایش شد");
            }
            else
            {
                throw new Exception($"دسته بندی با آیدی {id} یافت نشد");
            }
        }

        public async Task Delete(int CategoryId, CancellationToken cancellationToken)
        {
            var targetCat = await FindCategory(CategoryId, cancellationToken);
            if (targetCat != null)
            {
                targetCat.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception($"دسته بندی با آیدی {CategoryId} برای حذف یافت نشد!");
            }
        }

        public async Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServiceList(CancellationToken cancellationToken)
        {
            var categoriesWithServiceList = await _context.Categories.Select(c => new CategoriesWithServiceListDto
            {
                CategoryId = c.Id,
                Title = c.Title,
                PictureLocation = c.PictureLocation,
                Services = c.Services.Select(s => new ServicesInCategory
                {
                    Id = s.Id,
                    Title = s.Title,
                    CategoryTitle = s.Category.Title,
                    Description = s.Description,
                }).ToList()
            }).ToListAsync(cancellationToken);
            return categoriesWithServiceList ?? throw new Exception($"دسته بندی یافت نشد");
        }
        #endregion

        #region Private Methods
        private async Task<Category> FindCategory(int id, CancellationToken cancellationToken)
        {
            var Category = await _context.Categories.FindAsync(id, cancellationToken);
            return Category ?? throw new Exception($"دسته بندی با آیدی {id} یاف نشد!");
        }
        #endregion
    }
}
