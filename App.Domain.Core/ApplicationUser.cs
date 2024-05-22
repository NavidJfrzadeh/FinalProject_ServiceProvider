using App.Domain.Core.AdminEntity;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core;
public class ApplicationUser : IdentityUser<int>
{
    public Admin? Admin { get; set; }
    public Expert? Expert { get; set; }
    public Customer? Customer { get; set; }
    [MaxLength(100)]
    public string? FullName { get; set; }
}
