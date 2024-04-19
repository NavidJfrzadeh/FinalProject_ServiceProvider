using App.Domain.Core.CustomerEntity;

namespace App.Domain.Core.RequestEntity
{
    public class Request
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}