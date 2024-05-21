using App.Domain.Core.CategoryEntity.DTOs;

namespace GetService.Models
{
    public class HomePageViewModel
    {
        public List<GetAllCategoryForMainPageDto> CategoriesViewModel { get; set; } = new List<GetAllCategoryForMainPageDto>();
    }
}
