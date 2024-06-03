using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;

namespace App.Domain.AppService;
public class CategoryAppService : ICategoryAppService
{
    #region Fields
    private readonly ICategoryService _categoryService;
    #endregion

    #region Ctors
    public CategoryAppService(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #endregion

    #region Implementations
    public async Task Create(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken)
        => await _categoryService.Create(CategoryTitle, CategoryPicture, cancellationToken);

    public Task Update(int id, string Title, CancellationToken cancellationToken)
        => _categoryService.Update(id, Title, cancellationToken);

    public async Task Delete(int CategoryId, CancellationToken cancellationToken)
         => await _categoryService.Delete(CategoryId, cancellationToken);

    public async Task<List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryService.GetAll(cancellationToken);

    public async Task<List<CategoryDto>> GetCategories(CancellationToken cancellationToken)
        => await _categoryService.GetCategories(cancellationToken);

    public async Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServiceList(CancellationToken cancellationToken)
        => await _categoryService.GetCategoriesWithServiceList(cancellationToken);
    #endregion
}