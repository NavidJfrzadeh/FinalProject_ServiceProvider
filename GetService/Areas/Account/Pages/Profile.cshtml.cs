using App.Domain.Core;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.CustomerEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetService.Areas.Account.Pages
{
    [Authorize(Roles = "Customer,Expert")]
    public class ProfileModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ProfileModel(ICustomerAppService customerAppService, SignInManager<ApplicationUser> signIn)
        {
            _customerAppService = customerAppService;
            signInManager = signIn;
        }

        [BindProperty]
        public CustomerSummaryDto CustomerSummary { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            //var userId = int.Parse(User.Claims.First().Value);
            var userId = int.Parse(signInManager.UserManager.GetUserId(User));

            if (User.IsInRole("Customer"))
            {
                CustomerSummary = await _customerAppService.GetCustomerSummary(userId, cancellationToken);
            }

            if (User.IsInRole("Expert"))
            {

            }
        }


        public async Task OnPostAsync(CancellationToken cancellationToken)
        {
            if (User.IsInRole("Customer"))
            {
                await _customerAppService.UpdateProfile(CustomerSummary, cancellationToken);
            }

            if (User.IsInRole("Expert"))
            {

            }
        }

    }
}
