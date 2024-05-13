using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.Domain.Core.ServiceEntity.DTOs
{
    public class ServiceForUpdateDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "عنوان اجباری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "دسته بندی را انتخاب کنید")]
        [DisplayName("دسته بندی")]
        public int CategoryId { get; set; }
        [DisplayName("حذف شود؟")]
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [DisplayName("قیمت پایه")]
        public int BasePrice { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [MaxLength(500)]
        [DisplayName("آپلود عکس")]
        public string? ImageSrc { get; set; }
    }
}
