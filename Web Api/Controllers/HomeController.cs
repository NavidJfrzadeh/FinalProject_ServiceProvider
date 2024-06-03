using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Domain.Core.Enums;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        #region Fields
        private readonly ICategoryAppService _categoryAppService;
        private readonly IRequestAppService _requestAppService;
        private readonly IAccountAppService _accountAppService;
        #endregion

        #region Ctors
        public HomeController(ICategoryAppService categoryAppService,
            IRequestAppService requestAppService,
            IAccountAppService accountAppService
            )
        {
            _categoryAppService = categoryAppService;
            _requestAppService = requestAppService;
            _accountAppService = accountAppService;
        }
        #endregion

        [HttpGet]
        [Route(nameof(GetCategoriesWithServices))]
        public async Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServices(CancellationToken cancellationToken)
        {
            return await _categoryAppService.GetCategoriesWithServiceList(cancellationToken);
        }

        [HttpGet]
        [Route(nameof(GetAllRequests))]
        public async Task<List<RequestDto>> GetAllRequests(CancellationToken cancellationToken)
        {
            return await _requestAppService.GetAll(cancellationToken);
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel registerModel, CancellationToken cancellationToken)
        {
            registerModel.Errors = await _accountAppService.Register(registerModel.Name, registerModel.LastName, registerModel.Email, registerModel.Password, registerModel.IsExpert, registerModel.Gender);
            string Message = string.Empty;

            if (registerModel.Errors.Count > 0)
            {

                foreach (var error in registerModel.Errors)
                {
                    Message += error.Description + "\n";
                }
                return BadRequest(Message);
            }

            else
            {
                Message = "ثبت نام انجام شد";
                return Ok(Message);
            }
        }
    }
}