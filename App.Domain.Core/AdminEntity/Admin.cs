using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.AdminEntity
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FistName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
