﻿using App.Domain.Core._0_BaseEntities;
using App.Domain.Core.BidEntity;
using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CommentEntity;
using App.Domain.Core.Enums;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.ServiceEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.ExpertEntity
{
    public class Expert : BaseProperties
    {
        public Expert()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? ProfileImageUrl { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public List<Category>? Categories { get; set; }
        public decimal? Score { get; set; } //cause more load to application
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public List<Bid>? Bids { get; set; } = new List<Bid>();
        public List<Request>? AcceptedRequests { get; set; } = new List<Request>();
        public long? CardNumber { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
