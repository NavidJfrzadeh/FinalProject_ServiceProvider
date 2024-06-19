using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntities.Enums
{
    public enum Status
    {
        [Display(Name = "منتظر تایید درخواست")]
        WaitingForAcceptRequest = 1,
        [Display(Name = "در انتظار انتخاب کارشناس")]
        WaitingForChoosingExpert,
        [Display(Name = "کارشناس انتخاب شد")]
        AcceptExpert,
        [Display(Name = "اتمام درخواست")]
        RequestResponsed,
        [Display(Name = "درخواست شما توسط ادمین سایت رد شد")]
        RequestRejected
    }
}
