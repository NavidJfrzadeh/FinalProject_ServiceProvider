using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.CategoryEntity;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.ServiceEntity
{
    public class Service : SharedFields
    {
        public Service()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? ImageSrc { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Expert>? Experts { get; set; } = new List<Expert>();
        public List<Request>? Requests { get; set; } = new List<Request>();
    }
}
