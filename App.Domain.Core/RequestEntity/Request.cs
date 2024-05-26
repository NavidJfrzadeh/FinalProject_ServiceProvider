using App.Domain.Core._0_BaseEntities;
using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.BidEntity;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.RequestEntity
{
    public class Request : SharedFields
    {
        public Request()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            IsAccepted = false;
            Status = Status.level1;
            IsAcceptBid = false;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? ImageSrc { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime DateFor { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public List<Bid>? Bids { get; set; } = new List<Bid>();
        public Status Status { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsAcceptBid { get; set; }
    }
}