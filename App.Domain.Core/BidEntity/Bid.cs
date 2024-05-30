using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.BidEntity
{
    public class Bid : BaseProperties
    {
        public Bid()
        {
            IsAccepted = false;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime FinishedAt { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public bool IsAccepted { get; set; }
    }
}
