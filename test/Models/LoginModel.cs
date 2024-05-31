using System.ComponentModel.DataAnnotations;

namespace Web_Api.Models;

public class LoginModel
{
    [Display(Name = "ایمیل")]
    [Required]
    public string Email { get; set; }
    [Required]
    [Display(Name = "رمز عبور")]
    public string password { get; set; }
}
