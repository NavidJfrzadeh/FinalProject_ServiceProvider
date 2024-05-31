using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
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

        [HttpGet(Name = nameof(GetCategoriesWithServices))]
        public async Task<List<CategoriesWithServiceListDto>> GetCategoriesWithServices(CancellationToken cancellationToken)
        {
            return await _categoryAppService.GetCategoriesWithServiceList(cancellationToken);
        }

        [HttpGet(Name = nameof(GetAllRequests))]
        public async Task<List<RequestDto>> GetAllRequests(CancellationToken cancellationToken)
        {
            return await _requestAppService.GetAll(cancellationToken);
        }

        [HttpPost(Name = nameof(Login))]
        public async Task<IActionResult> Login(LoginModel loginModel, CancellationToken cancellationToken)
        {
            var isLogin = await _accountAppService.Login(loginModel.Email, loginModel.password);
            if (isLogin) return Ok();
            return NotFound();
        }

        [HttpPost(Name = nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel registerModel, CancellationToken cancellationToken)
        {
            registerModel.Errors = await _accountAppService.Register(registerModel.Name, registerModel.LastName, registerModel.Email, registerModel.Password, registerModel.IsExpert);
            return Ok();
        }
    }
}