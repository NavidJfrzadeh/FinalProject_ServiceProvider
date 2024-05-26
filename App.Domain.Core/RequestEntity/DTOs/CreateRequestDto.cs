namespace App.Domain.Core.RequestEntity.DTOs;

public class CreateRequestDto
{
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string? RequestImage { get; set; }
    public DateTime DateFor { get; set; }
}
