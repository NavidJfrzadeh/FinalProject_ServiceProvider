using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.Domain.Core.ServiceEntity.DTOs
{
    public class ServiceCreateDto
    {
        [Required(ErrorMessage = "عنوان اجباری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [MaxLength(500)]
        [DisplayName("آپلود عکس")]
        public string? ImageSrc { get; set; }
        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [DisplayName("قیمت پایه")]
        public int BasePrice { get; set; }
        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string? Description { get; set; }
        [DisplayName("دسته‌بندی")]
        [Required(ErrorMessage = "دسته بندی را انتخاب کنید")]
        public int CategoryId { get; set; }
    }
}
