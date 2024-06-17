using App.Domain.Core._0_BaseEntities;
using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.BidEntity;
using App.Domain.Core.CommentEntity;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.RequestEntity
{
    public class Request : BaseProperties
    {
        public Request()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            IsAccepted = false;
            Status = Status.WaitingForAcceptRequest;
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
        public int? CommentId { get; set; }
        public Comment? Comment { get; set; }
        public Status Status { get; set; }
        public int? AcceptedExpertId { get; set; }
        public Expert? AcceptedExpert { get; set; }
        public bool IsAccepted { get; set; }
    }
}