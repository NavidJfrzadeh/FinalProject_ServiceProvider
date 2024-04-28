using App.Domain.Core.CategoryEntity.DTOs;

namespace App.Domain.Core.CategoryEntity.Contracts
{
    public interface ICategoryRepository
    {
        public List<GetAllCategoryForMainPageDto> GetAll();
    }
}
