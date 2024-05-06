using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.CustomerEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        [MaxLength(500)]
        public string Street { get; set; }

        [StringLength(10)]
        public char PostalCode { get; set; }
        public int PlateNumber { get; set; }
        [StringLength(13)]
        public string PhoneNumber { get; set; }
    }
}
