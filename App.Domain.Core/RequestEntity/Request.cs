using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.CustomerEntity;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.RequestEntity
{
    public class Request
    {
        public Request()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public Status Status { get; set; } = Status.level1;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}