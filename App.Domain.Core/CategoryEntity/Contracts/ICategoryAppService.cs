using App.Domain.Core.CategoryEntity.DTOs;

namespace App.Domain.Core.CategoryEntity.Contracts;
public interface ICategoryAppService
{
    public Task<List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken);
    public Task<List<CategoriesForCreateServiceDto>> GetCategories(CancellationToken cancellationToken);
    public Task Create(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken);
    public Task Update(int id, string Title, CancellationToken cancellationToken);
    public Task Delete(int CategoryId, CancellationToken cancellationToken);
    public Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServiceList(CancellationToken cancellationToken);
}
