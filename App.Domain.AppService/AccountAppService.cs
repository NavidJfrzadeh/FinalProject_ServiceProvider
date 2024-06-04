using App.Domain.Core;
using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.Enums;
using App.Domain.Core.ExpertEntity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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

    public async Task<List<IdentityError>> Register(string firstName, string lastName, string email, string password, bool isExpert, Gender gender)
    {
        var user = CreateUser();
        user.Email = email;
        user.UserName = email;
        user.FullName = string.Format("{0} {1}", firstName, lastName);
        var role = string.Empty;

        if (isExpert)
        {
            role = "Expert";
            user.Expert = new Expert()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                FullName = string.Format("{0} {1}", firstName, lastName)
            };
        }
        else
        {
            role = "Customer";
            user.Customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                FullName = string.Format("{0} {1}", firstName, lastName)
            };
        }

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            if (isExpert)
            {
                var userExpertId = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
            }

            else
            {
                var userCustomerId = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
            }

            await _userManager.AddToRoleAsync(user, role);
        }

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
