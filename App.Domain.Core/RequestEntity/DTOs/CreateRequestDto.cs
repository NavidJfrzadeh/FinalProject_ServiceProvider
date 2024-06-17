using App.Domain.Core._0_CustomAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.RequestEntity.DTOs;

public class CreateRequestDto
{
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "توضیحات را وارد کنید")]
    public string Description { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImageAddress { get; set; }
    [RequestDateValidation(ErrorMessage = "تاریخ ورودی اشتباه است!")]
    [Required(ErrorMessage = "تاریخ را وارد کنید")]
    public string PersianDate { get; set; }
    public DateTime DateFor { get; set; }
}