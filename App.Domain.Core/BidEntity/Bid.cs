using App.Domain.Core.ExpertEntity;

namespace App.Domain.Core.BidEntity
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
    }
}
