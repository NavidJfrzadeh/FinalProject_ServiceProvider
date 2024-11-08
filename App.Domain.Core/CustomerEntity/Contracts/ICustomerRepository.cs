﻿using App.Domain.Core.CustomerEntity.DTOs;

namespace App.Domain.Core.CustomerEntity.Contracts
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(int id, CancellationToken cancellationToken);
        public Task<List<CustomerListDto>> GetAll(CancellationToken cancellationToken);
        public Task<bool> Register(Customer customer, CancellationToken cancellationToken);
        public Task<CustomerSummaryDto> GetCustomerSummary(int CustomerId, CancellationToken cancellationToken);
        public Task UpdateProfile(CustomerSummaryDto customerSummary, CancellationToken cancellationToken);
    }
}
