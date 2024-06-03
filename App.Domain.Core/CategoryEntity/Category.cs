using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CategoryEntity
{
    public class Category : BaseProperties
    {
        public Category()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [MaxLength(500)]
        public string? PictureLocation { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public List<Service>? Services { get; set; } = new List<Service>();
        public List<Expert>? Experts { get; set; }
    }
}
