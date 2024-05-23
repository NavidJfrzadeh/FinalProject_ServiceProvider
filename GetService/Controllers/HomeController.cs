using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using App.Domain.Core.ServiceEntity.Contracts;
using GetService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IServicesAppService _servicesAppService;
        private readonly IRequestAppService _requestAppSerice;

        public HomeController(ILogger<HomeController> logger, ICategoryAppService categoryAppService,
            IServicesAppService servicesAppService,
            IRequestAppService requestAppSerice
            )
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _servicesAppService = servicesAppService;
            _requestAppSerice = requestAppSerice;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var homeViewModel = new HomePageViewModel();
            homeViewModel.CategoriesViewModel = await _categoryAppService.GetAll(cancellationToken);
            return View(homeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ServicesInCategory(int id, CancellationToken cancellationToken)
        {
            var services = await _servicesAppService.GetServicesInCategory(id, cancellationToken);
            return View(services);
        }

        [HttpGet]
        public async Task<IActionResult> ServiceDetails(int id, CancellationToken cancellationToken)
        {
            var service = await _servicesAppService.GetDetails(id, cancellationToken);
            return View(service);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRequest(int serviceId, string Description, CancellationToken cancellationToken)
        {
            var CreateRequestDto = new CreateRequestDto
            {
                CustomerId = int.Parse(User.Claims.First().Value),
                ServiceId = serviceId,
                Description = Description
            };

            var result = await _requestAppSerice.Create(CreateRequestDto, cancellationToken);

            if (result)
            {
                TempData["RequestCreated"] = "درخواست شما با موفقیت ثبت شد";
                return RedirectToAction("ServiceDetails", new { id = serviceId });
            }

            TempData["RequestFailed"] = "ثبت درخواست شما ناموفق بود";
            return RedirectToAction("ServiceDetails", new { id = serviceId });
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
