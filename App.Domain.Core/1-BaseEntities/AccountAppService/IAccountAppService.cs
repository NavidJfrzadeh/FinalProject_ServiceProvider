using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core._1_BaseEntities.AccountAppService;
public interface IAccountAppService
{
    public Task<bool> Login(string Email, string Password);
    public Task<List<IdentityError>> Register(string fullName, string Email, string password, bool isExpert);
}
