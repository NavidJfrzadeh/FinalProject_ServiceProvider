using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.CommentEntity
{
    public class Comment : BaseProperties
    {
        public Comment()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            IsAccepted = false;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "امتیاز باید بین 0 تا 10 باشد")]
        [Column(TypeName = "decimal(18, 1)")]
        public decimal Score { get; set; } = 0;
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public Request? Request { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
    }
}
