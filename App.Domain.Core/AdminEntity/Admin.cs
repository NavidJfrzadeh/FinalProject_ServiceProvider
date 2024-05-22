using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.AdminEntity;

public class Admin
{
    public Admin()
    {
        FullName = string.Format("{0} {1}", FistName, LastName);
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string FistName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string FullName { get; set; }
    [MaxLength(500)]
    public string? ProfileImageUrl { get; set; }
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
