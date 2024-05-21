using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.ServiceEntity.Contracts;
using GetService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IServicesAppService _servicesAppService;

        public HomeController(ILogger<HomeController> logger, ICategoryAppService categoryAppService, IServicesAppService servicesAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _servicesAppService = servicesAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var homeViewModel = new HomePageViewModel();
            homeViewModel.CategoriesViewModel = await _categoryAppService.GetAll(cancellationToken);
            return View(homeViewModel);
        }

        public async Task<IActionResult> ServicesInCategory(int id, CancellationToken cancellationToken)
        {
            var services = await _servicesAppService.GetServicesInCategory(id,cancellationToken);
            return View(services);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
