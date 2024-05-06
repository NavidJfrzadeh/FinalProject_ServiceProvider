using App.Domain.Core._1_CustomAttributes;

namespace App.Domain.Core._0_BaseEntities.Enums
{
    public enum Status
    {
        [StringValue("منتظر تایید درخواست")]
        level1 = 1,
        [StringValue("منتظر تایید کارشناس")]
        level2,
        [StringValue("تایید شده توسط کارشناس")]
        level3,
        [StringValue("درخواست شما توسط ادمین سایت رد شد")]
        level4
    }
}
