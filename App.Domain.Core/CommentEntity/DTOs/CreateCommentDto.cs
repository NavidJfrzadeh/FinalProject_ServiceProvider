using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CommentEntity.DTOs;

public class CreateCommentDto
{
    [Required]
    [Display(Name = "عنوان")]
    public string Title { get; set; }
    public int CustomerId { get; set; }
    public int ExpertId { get; set; }
    [Required]
    [Display(Name = "امتیاز دهید 0 تا 10")]
    public int Score { get; set; }
    [Required]
    [Display(Name = "متن نظر")]
    public string Description { get; set; }
}
