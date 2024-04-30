using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<GetAllCategoryForMainPageDto> GetAll()
        {
            var Categories = _context.Categories.AsNoTracking().Select(c=> new GetAllCategoryForMainPageDto
            {
                Id = c.Id,
                title = c.Title,
                CountService = c.Services.Count
            }).ToList();

            return Categories;
        }
    }
}
