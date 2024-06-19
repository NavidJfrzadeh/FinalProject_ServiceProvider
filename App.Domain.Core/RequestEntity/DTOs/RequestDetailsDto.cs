using App.Domain.Core._0_BaseEntities.Enums;

namespace App.Domain.Core.RequestEntity.DTOs;

public class RequestDetailsDto
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public string CustomerFullName { get; set; }
    public string? ImageSrc { get; set; }
    public Status RequestStatus { get; set; }
    public bool IsAccepted { get; set; }
}