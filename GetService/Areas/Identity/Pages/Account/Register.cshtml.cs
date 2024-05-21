using App.Domain.Core._1_BaseEntities.AccountAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GetService.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountAppService _accountAppService;

        public RegisterModel(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public class RegisterViewModel
        {
            [Display(Name = "نام و نام خانوادگی(با فاصله)")]
            public string FullName { get; set; }
            [Display(Name = "ایمیل")]
            public string Email { get; set; }
            [Display(Name = "رمز عبور")]
            public string Password { get; set; }
            [Display(Name = "کارشناس هستید؟")]
            public bool IsExpert { get; set; }
        }

        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [BindProperty]
        public LoginViewModel LoginView { get; set; }

        [BindProperty]
        public RegisterViewModel RegisterView { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var result = await _accountAppService.Register(RegisterView.FullName, RegisterView.Email, RegisterView.Password, RegisterView.IsExpert);

            if (result.Count == 0)
            {
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }


        public void OnPostLogin()
        {

        }
    }
}
