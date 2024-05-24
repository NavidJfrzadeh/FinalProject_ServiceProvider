using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Core.ServiceEntity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        #region Fields
        private readonly ICategoryAppService _categoryAppService;
        private readonly IServicesAppService _servicesAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IRequestAppService _requestAppService;
        #endregion

        public AdminController(ICategoryAppService categoryAppService,
            IServicesAppService servicesAppService,
            ICommentAppService commentAppService,
            IRequestAppService requestAppService)
        {
            _categoryAppService = categoryAppService;
            _servicesAppService = servicesAppService;
            _commentAppService = commentAppService;
            _requestAppService = requestAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            TempData["UnAccesptedCommentsCount"] = await _commentAppService.GetUnAcceptedCommentsCount(cancellationToken);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList(CancellationToken cancellationToken)
        {
            var categories = await _categoryAppService.GetAll(cancellationToken);
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryServices(int id, CancellationToken cancellationToken)
        {
            var services = await _servicesAppService.GetCategoryServices(id, cancellationToken);
            ViewData["CategoryServices"] = services;
            return RedirectToAction("ServiceList");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string CategoryTitle, string CategoryPicture, CancellationToken cancellationToken)
        {
            ModelState.Remove(nameof(CategoryPicture));
            if (ModelState.IsValid)
            {
                await _categoryAppService.Create(CategoryTitle, CategoryPicture, cancellationToken);
                return RedirectToAction("CategoryList");
            }
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int Id, string Title, CancellationToken cancellationToken)
        {
            await _categoryAppService.Update(Id, Title, cancellationToken);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            await _categoryAppService.Delete(id, cancellationToken);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> ServiceList(CancellationToken cancellationToken)
        {
            var services = await _servicesAppService.GetServiceList(cancellationToken);
            return View(services);
        }

        public async Task<IActionResult> ServiceCreate(CancellationToken cancellationToken)
        {
            ViewData["CategoriesTitle"] = await _categoryAppService.GetCategories(cancellationToken);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCreate(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _servicesAppService.Create(serviceCreateDto, cancellationToken);
                return RedirectToAction("ServiceList");
            }
            ViewData["CategoriesTitle"] = await _categoryAppService.GetCategories(cancellationToken);
            return View(serviceCreateDto);
        }

        public async Task<IActionResult> ServiceDelete(int id, CancellationToken cancellationToken)
        {
            await _servicesAppService.Delete(id, cancellationToken);
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public async Task<IActionResult> ServiceUpdate(int id, CancellationToken cancellationToken)
        {
            var serviceModel = await _servicesAppService.GetServiceForUpdate(id, cancellationToken);
            ViewData["CategoriesTitle"] = await _categoryAppService.GetCategories(cancellationToken);
            return View(serviceModel);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceUpdate(ServiceForUpdateDto serviceModel, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _servicesAppService.Update(serviceModel, cancellationToken);
                return RedirectToAction("ServiceList");
            }
            ViewData["CategoriesTitle"] = await _categoryAppService.GetCategories(cancellationToken);
            return View(serviceModel);
        }

        public async Task<IActionResult> ServiceDetails(int id, CancellationToken cancellationToken)
        {
            var service = await _servicesAppService.GetById(id, cancellationToken);
            return View(service);
        }

        [HttpGet]
        public async Task<IActionResult> CommentForAccept(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                var commentsForAccept = await _commentAppService.GetUnAcceptedComments(cancellationToken);
                return View(commentsForAccept);
            }
            else
            {
                await _commentAppService.Accept(id, cancellationToken);
                var commentsForAccept = await _commentAppService.GetUnAcceptedComments(cancellationToken);
                return View(commentsForAccept);
            }
        }

        public async Task<IActionResult> CommentDetails(int id, CancellationToken cancellationToken)
        {
            var commentDto = await _commentAppService.GetById(id, cancellationToken);
            return View(commentDto);
        }

        public async Task<IActionResult> CommentDelete(int id, CancellationToken cancellationToken)
        {
            _commentAppService.Delete(id, cancellationToken);
            return View();
        }

        public async Task<IActionResult> RequestsList(CancellationToken cancellationToken)
        {
            var requests = await _requestAppService.GetAll(cancellationToken);
            return View(requests);
        }

        public async Task<IActionResult> RequestDetails(int id, CancellationToken cancellationToken)
        {
            var request = await _requestAppService.GetById(id, cancellationToken);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> RequestSetStatus(int id, Status status, CancellationToken cancellationToken)
        {
            await _requestAppService.SetRequestStatus(id, null, status, cancellationToken);
            return RedirectToAction("RequestsList");
        }
        public async Task<IActionResult> CustomerList(CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
