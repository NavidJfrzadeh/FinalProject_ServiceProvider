using App.Domain.Core.CommentEntity;
using App.Domain.Core.Enums;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.ExpertEntity
{
    public class Expert
    {
        public Expert()
        {
            CreatedAt = DateTime.Now; 
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? ProfilePhoto { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        [MaxLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
        [MaxLength(11)]
        public string PhoneNumberBackUp { get; set; }
        public decimal Score { get; set; } = 0; // can cause more load to application
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public List<Service>? Services { get; set; } = new List<Service>();
        public long CardNumber { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
