using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GetService.Areas.Account.Pages
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
            [Display(Name = "نام")]
            [Required(ErrorMessage = "نام الزامی است")]
            public string Name { get; set; }
            [Display(Name = "نام خانوادگی")]
            [Required(ErrorMessage = "نام خانوادگی الزامی است")]
            public string LastName { get; set; }
            [Display(Name = "ایمیل")]
            [Required(ErrorMessage = "ایمیل الزامی است")]
            public string Email { get; set; }
            [Display(Name = "رمز عبور")]
            [Required(ErrorMessage = "رمز عبور الزامی  است")]
            public string Password { get; set; }
            public Gender Gender { get; set; }
            [Display(Name = "کارشناس هستید؟")]
            public bool IsExpert { get; set; }
        }

        [BindProperty]
        public RegisterViewModel RegisterView { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return Page();

            var Errors = await _accountAppService.Register(RegisterView.Name, RegisterView.LastName, RegisterView.Email, RegisterView.Password, RegisterView.IsExpert, RegisterView.Gender);

            if (Errors.Count == 0)
            {
                return LocalRedirect(returnUrl);
            }

            foreach (var error in Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }


        public async Task<IActionResult> OnPostLogin(string Email, string Password, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (Email == null || Password == null)
            {
                TempData["Error"] = "ایمیل و رمز عبور را وارد کنید";
                return LocalRedirect(returnUrl);
            }

            var succeedLogin = await _accountAppService.Login(Email, Password);

            if (succeedLogin)
                return Redirect(returnUrl);

            else
            {
                TempData["Error"] = "ایمیل یا کلمه عبور اشتباه است";
                return LocalRedirect(returnUrl);
            }
        }
    }
}
