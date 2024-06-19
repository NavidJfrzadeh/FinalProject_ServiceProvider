using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CommentEntity.DTOs;

public class CreateCommentDto
{
    [Required(ErrorMessage ="عنوان را وارد کنید!")]
    [Display(Name = "عنوان")]
    public string Title { get; set; }
    public int CustomerId { get; set; }
    public int ExpertId { get; set; }
    public int RequestId { get; set; }
    [Required(ErrorMessage ="امتیاز دهید")]
    [Display(Name = "امتیاز دهید")]
    public int Score { get; set; }
    [Required(ErrorMessage = "متن نظر را وارد کنید!")]
    [Display(Name = "متن نظر")]
    public string Description { get; set; }
}
