using App.Domain.Core.ServiceEntity.DTOs;

namespace App.Domain.Core.CategoryEntity.DTOs;

public class CategoriesWithServiceListDto
{
    public int CategoryId { get; set; }
    public string PictureLocation { get; set; }
    public string Title { get; set; }
    public List<ServicesInCategory>? Services { get; set; }
}
