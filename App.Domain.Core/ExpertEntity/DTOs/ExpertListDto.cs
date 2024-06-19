namespace App.Domain.Core.ExpertEntity.DTOs;

public class ExpertListDto
{
    public int ExpertId { get; set; }
    public string ExpertFullName { get; set; }
    public string? ProfileImage { get; set; }
    public decimal? ExpertScore { get; set; }
}
