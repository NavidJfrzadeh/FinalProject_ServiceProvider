using App.Domain.Core.AdminEntity;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core;
public class ApplicationUser : IdentityUser<int>
{
    public int AdminId { get; set; }
    public Admin? Admin { get; set; }
    public int ExpertId { get; set; }
    public Expert? Expert { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

}
