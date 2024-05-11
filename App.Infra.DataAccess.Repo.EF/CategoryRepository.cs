using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
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
            var Categories = _memoryCache.Get<List<GetAllCategoryForMainPageDto>>("Categories");
            if (Categories == null)
            {
                Categories = await _context.Categories.AsNoTracking().Select(c => new GetAllCategoryForMainPageDto
                {
                    Id = c.Id,
                    title = c.Title,
                    CountService = c.Services.Count
                }).ToListAsync(cancellationToken);
                _memoryCache.Set("Categories", Categories);
            }
            return Categories;
        }

        public async Task Create(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken)
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

        public async Task Delete(int CategoryId, CancellationToken cancellationToken)
        {
            var targetCat = await FindCategory(CategoryId, cancellationToken);
            if (targetCat != null)
            {
                targetCat.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        #endregion

        #region Private Methods
        private async Task<Category> FindCategory(int id, CancellationToken cancellationToken)
        {
            var Category = await _context.Categories.FindAsync(id, cancellationToken);
            if (Category != null)
            {
                return Category;
            }
            throw new Exception($"Category with Id {id} not found");
        }
        #endregion
    }
}
