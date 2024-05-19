using App.Domain.Core._0_BaseEntities;
using App.Domain.Core._0_BaseEntity;
using App.Domain.Core.CommentEntity;
using App.Domain.Core.Enums;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CustomerEntity
{
    public class Customer : SharedFields
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            FullName = string.Format("{0} {1}",FirstName,LastName);
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? ProfileImageUrl { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength (150)]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public List<Request>? Requests { get; set; } = new List<Request>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
