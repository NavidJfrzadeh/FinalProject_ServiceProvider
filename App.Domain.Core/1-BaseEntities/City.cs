using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
