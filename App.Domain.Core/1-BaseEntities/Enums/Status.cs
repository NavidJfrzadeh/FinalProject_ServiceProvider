using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntities.Enums
{
    public enum Status
    {
        [Display(Name = "منتظر تایید درخواست")]
        level1 = 1,
        [Display(Name = "منتظر تایید کارشناس")]
        level2,
        [Display(Name = "تایید شده توسط کارشناس")]
        level3,
        [Display(Name = "درخواست شما توسط ادمین سایت رد شد")]
        level4
    }
}
