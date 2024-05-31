using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;

namespace App.Domain.Service
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Ctors
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Implementations
        public async Task Create(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken)
            => await _categoryRepository.Create(CategoryTitle, CategoryPicture, cancellationToken);

        public Task Update(int id, string Title, CancellationToken cancellationToken)
            => _categoryRepository.Update(id, Title, cancellationToken);

        public async Task Delete(int CategoryId, CancellationToken cancellationToken)
            => await _categoryRepository.Delete(CategoryId, cancellationToken);

        public async Task<List<GetAllCategoryForMainPageDto>> GetAll(CancellationToken cancellationToken)
            => await _categoryRepository.GetAll(cancellationToken);

        public async Task<List<CategoriesForCreateServiceDto>> GetCategories(CancellationToken cancellationToken)
            => await _categoryRepository.GetCategories(cancellationToken);

        public async Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServiceList(CancellationToken cancellationToken)
            => await _categoryRepository.GetCategoriesWithServiceList(cancellationToken);
        #endregion
    }
}
