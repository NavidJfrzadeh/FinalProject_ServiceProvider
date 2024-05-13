﻿using App.Domain.Core.CategoryEntity.Contracts;
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
        #endregion

        public AdminController(ICategoryAppService categoryAppService, IServicesAppService servicesAppService)
        {
            _categoryAppService = categoryAppService;
            _servicesAppService = servicesAppService;
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

        public async Task<IActionResult> CustomerList(CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
