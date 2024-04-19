using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CategoryEntity
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
    }
}
