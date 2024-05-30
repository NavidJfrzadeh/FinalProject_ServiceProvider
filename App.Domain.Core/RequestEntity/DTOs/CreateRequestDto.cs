using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.RequestEntity.DTOs;

public class CreateRequestDto
{
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImageAddress { get; set; }
    public string PersianDate { get; set; }
    public DateTime DateFor { get; set; }
}