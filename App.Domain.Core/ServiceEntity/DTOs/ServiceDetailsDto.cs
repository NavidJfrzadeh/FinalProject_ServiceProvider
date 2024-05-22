namespace App.Domain.Core.ServiceEntity.DTOs;
public class ServiceDetailsDto
{
    public int ServiceId { get; set; }
    public string Title { get; set; }
    public string CategoryTitle { get; set; }
    public string? ImageSrc { get; set; }
    public int BasePrice { get; set; }
    public string Description { get; set; }
}
