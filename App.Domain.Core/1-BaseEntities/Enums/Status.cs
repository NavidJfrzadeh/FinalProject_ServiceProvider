using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._0_BaseEntities.Enums
{
    public enum Status
    {
        [Display(Name = "منتظر تایید درخواست")]
        WaitingForAcceptRequest = 1,
        [Display(Name = "در انتظار انتخاب کارشناس")]
        WaitingForChoosingExpert,
        [Display(Name = "تایید کارشناس")]
        AcceptExpert,
        [Display(Name = "به درخواست شما پاسخ داده شد")]
        RequestResponsed,
        [Display(Name = "نظر شما ثبت شد")]
        CommentSubmited,
        [Display(Name = "درخواست شما توسط ادمین سایت رد شد")]
        RequestRejected
    }
}
