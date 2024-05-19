using App.Domain.Core;
using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.AppService;
public class AccountAppService : IAccountAppService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountAppService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> Login(string Email, string Password)
    {
        var result = await _signInManager.PasswordSignInAsync(Email, Password, isPersistent: true, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<List<IdentityError>> Register(string userName, string email, string password, bool isCustomer, bool isExpert)
    {
        var user = CreateUser();
        user.Email = email;
        user.UserName = userName;

        var role = string.Empty;

        if (isCustomer)
        {
            role = "Customer";
            user.Customer = new Customer();
        }

        if (isExpert)
        {
            role = "Expert";
            user.Expert = new Expert();
        }

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, role);

        return (List<IdentityError>)result.Errors;
    }


    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch (Exception)
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                                                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
}
