using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CommentEntity
{
    public class Comment : SharedFields
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
        public decimal Score { get; set; } = 0;
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
    }
}
