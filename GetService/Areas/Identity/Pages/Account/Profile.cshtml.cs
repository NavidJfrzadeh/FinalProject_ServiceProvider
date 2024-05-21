using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetService.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Customer,Expert")]
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
