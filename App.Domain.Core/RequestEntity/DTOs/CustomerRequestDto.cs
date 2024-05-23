﻿using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.DTOs;

namespace App.Domain.Core.RequestEntity.DTOs;

public class CustomerRequestDto
{
    public int RequestId { get; set; }
    public string? RequestImage { get; set; }
    public string ServiceTitle { get; set; }
    public string CreateDateFa { get; set; }
    public List<CustomerRequestBidsDto>? Bids { get; set; }
    public Status Status { get; set; }
}