using App.Domain.Core._0_BaseEntities.Enums;

namespace App.Domain.Core.BidEntity.DTOs;

public class CustomerRequestBidsDto
{
    public int BidId { get; set; }
    public int Price { get; set; }
    public string FinishedAtFa { get; set; }
    public string Description { get; set; }
    public int ExpertId { get; set; }
    public string ExpertFullName { get; set; }
    public bool IsAccepted { get; set; }
}