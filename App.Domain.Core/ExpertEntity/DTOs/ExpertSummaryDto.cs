namespace App.Domain.Core.ExpertEntity.DTOs;

public class ExpertSummaryDto
{
    public int ExpertId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ImageAddress { get; set; }
    public List<int>? CategoryIds { get; set; }
}
