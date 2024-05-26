using App.Domain.Core._0_BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CustomerEntity.DTOs;
public class CustomerSummaryDto
{
    public int Id { get; set; }
    [Display(Name ="نام")]
    public string FirstName { get; set; }
    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; }
    public string? ProfileImage { get; set; }
    public List<Address>? Addresses { get; set; }
    [Display(Name = "ایمیل")]
    public string? Email { get; set; }
    [Display(Name = "شماره همراه")]
    public string? PhoneNumber { get; set; }
}
