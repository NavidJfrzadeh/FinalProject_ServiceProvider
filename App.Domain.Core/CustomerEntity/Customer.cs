﻿using App.Domain.Core.Enums;
using App.Domain.Core.RequestEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.CustomerEntity
{
    public class Customer
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        [MaxLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
        public List<Request>? Requests { get; set; } = new List<Request>();
        public DateTime RegisteredAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}