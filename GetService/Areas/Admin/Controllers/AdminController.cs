using App.Domain.Core.CategoryEntity.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        #region Fields
        private readonly ICategoryAppService _categoryAppService;
        #endregion

        public AdminController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList(CancellationToken cancellationToken)
        {
            var categories = await _categoryAppService.GetAll(cancellationToken);
            return View(categories);
        }

        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string CategoryTitle, string CategoryPicture,CancellationToken cancellationToken)
        {
            ModelState.Remove(nameof(CategoryPicture));
            if(ModelState.IsValid)
            {
                await _categoryAppService.Create(CategoryTitle, CategoryPicture, cancellationToken);
                return RedirectToAction("CategoryList");
            }
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int Id,string Title, CancellationToken cancellationToken)
        {
            //await _categoryAppService.Update(int id,cancellationToken);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            await _categoryAppService.Delete(id, cancellationToken);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> CustomerList(CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
