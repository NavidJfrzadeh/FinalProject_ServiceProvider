using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.BidEntity.DTOs;

public class CreateBidDto
{
    [Required(ErrorMessage = "قیمت را وارد کنید")]
    [DisplayName("قیمت")]
    public int Price { get; set; }
    [Required(ErrorMessage = "تاریخ را وارد کنید")]
    [DisplayName("تاریخ اتمام کار")]
    public string PersianDate { get; set; }
    public DateTime? DateFor { get; set; }
    [Required(ErrorMessage = "توضیحات پیشنهادتان را وارد کنید")]
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public int RequestId { get; set; }
    public int ExpertId { get; set; }
}
