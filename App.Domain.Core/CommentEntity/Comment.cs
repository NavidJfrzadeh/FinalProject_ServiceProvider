using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CommentEntity
{
    public class Comment
    {
        public Comment()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Score { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
