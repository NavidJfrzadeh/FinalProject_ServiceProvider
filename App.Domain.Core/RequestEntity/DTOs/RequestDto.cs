using App.Domain.Core._0_BaseEntities.Enums;

namespace App.Domain.Core.RequestEntity.DTOs
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceTitle { get; set; }
        public Status Status { get; set; }
        public bool IsAccepted { get; set; }
        public bool? HasExpertBid { get; set; } // check if current expert  already written a suggestion for request.
        public bool? IsAcceptedBid { get; set; } // if there is any suggestions check that suggestion was accepted by Customer.
    }
}
