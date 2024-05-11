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

    public async Task Delete(int CategoriesId, CancellationToken cancellationToken)
         => await _categoryService.Delete(CategoriesId, cancellationToken);

    public async Task<List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryService.GetAll(cancellationToken);
    #endregion
}