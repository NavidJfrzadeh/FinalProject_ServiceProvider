using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Ctors
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task< List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken)
        {
            var Categories = await  _context.Categories.AsNoTracking().Select(c => new GetAllCategoryForMainPageDto
            {
                Id = c.Id,
                title = c.Title,
                CountService = c.Services.Count
            }).ToListAsync(cancellationToken);

            return Categories;
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
