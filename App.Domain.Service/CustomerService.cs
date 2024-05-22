using App.Domain.Core.CustomerEntity;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.CustomerEntity.DTOs;

namespace App.Domain.Service;
public class CustomerService : ICustomerService
{
    #region Fields
    private readonly ICustomerRepository _customerRepository;
    #endregion

    #region Ctors
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    #endregion

    #region Implementations
    public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
        => await _customerRepository.GetAll(cancellationToken);

    public async Task<Customer> GetById(int id, CancellationToken cancellationToken)
        => await _customerRepository.GetById(id, cancellationToken);

    public async Task<CustomerSummaryDto> GetCustomerSummary(int CustomerId, CancellationToken cancellationToken)
        => await _customerRepository.GetCustomerSummary(CustomerId, cancellationToken);

    public async Task<bool> Register(Customer customer, CancellationToken cancellationToken)
        => await _customerRepository.Register(customer, cancellationToken);

    public async Task UpdateProfile(CustomerSummaryDto customerSummary, CancellationToken cancellationToken)
        => await _customerRepository.UpdateProfile(customerSummary, cancellationToken);
    #endregion
}
