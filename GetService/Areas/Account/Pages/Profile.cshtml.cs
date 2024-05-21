using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetService.Areas.Account.Pages
{
    [Authorize(Roles = "Customer,Expert")]
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
