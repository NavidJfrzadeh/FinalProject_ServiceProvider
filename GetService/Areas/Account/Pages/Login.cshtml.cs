using App.Domain.Core._1_BaseEntities.AccountAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace GetService.Areas.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountAppService _accountAppService;

        public LoginModel(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        public class LoginViewModel
        {
            [Display(Name = "ایمیل")]
            [Required]
            public string Email { get; set; }
            [Required]
            [Display(Name = "رمز عبور")]
            public string password { get; set; }
        }

        [BindProperty]
        public LoginViewModel LoginView { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return Page();

            var succeedLogin = await _accountAppService.Login(LoginView.Email, LoginView.password);

            if (succeedLogin)
                return LocalRedirect(returnUrl);

            else
            {
                ModelState.AddModelError(string.Empty, "ایمیل یا رمز عبور اشتباه است");
                return Page();
            }
        }
    }
}
