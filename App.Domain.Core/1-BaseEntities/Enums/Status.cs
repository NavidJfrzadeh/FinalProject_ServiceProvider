using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntities.Enums
{
    public enum Status
    {
        [Display(Name = "منتظر تایید درخواست")]
        level1 = 1,
        [Display(Name = "در انتظار انتخاب کارشناس")]
        level2,
        [Display(Name = "تایید کارشناس")]
        level3,
        [Display(Name = "به درخواست شما پاسخ داده شد")]
        level4,
        [Display(Name = "درخواست شما توسط ادمین سایت رد شد")]
        level5
    }
}
