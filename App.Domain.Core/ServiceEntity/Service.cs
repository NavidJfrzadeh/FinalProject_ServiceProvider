using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.CategoryEntity;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using System.ComponentModel;
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
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [MaxLength(500)]
        [DisplayName("آپلود عکس")]
        public string? ImageSrc { get; set; }
        [Required]
        [DisplayName("قیمت پایه")]
        public int BasePrice {  get; set; }
        [MaxLength(2000)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("دسته‌بندی")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Expert>? Experts { get; set; } = new List<Expert>();
        public List<Request>? Requests { get; set; } = new List<Request>();
    }
}
