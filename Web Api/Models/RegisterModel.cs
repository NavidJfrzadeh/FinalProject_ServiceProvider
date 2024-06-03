using App.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web_Api.Models;

public class RegisterModel
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
    public List<IdentityError> Errors { get; set; }
}
