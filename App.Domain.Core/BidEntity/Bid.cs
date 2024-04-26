﻿using App.Domain.Core.ExpertEntity;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.BidEntity
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateOnly StartAt { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
    }
}
