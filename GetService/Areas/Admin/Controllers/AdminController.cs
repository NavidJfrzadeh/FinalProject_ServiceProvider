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
