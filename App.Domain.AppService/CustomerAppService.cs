using App.Domain.Core.CustomerEntity;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.CustomerEntity.DTOs;

namespace App.Domain.AppService;

public class CustomerAppService : ICustomerAppService
{
    #region Fields
    private readonly ICustomerService _customerService;
    #endregion

    #region Ctors
    public CustomerAppService(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    #endregion

    #region Implementations
    public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
        => await _customerService.GetAll(cancellationToken);

    public async Task<Customer> GetById(int id, CancellationToken cancellationToken)
        => await _customerService.GetById(id, cancellationToken);

    public async Task<CustomerSummaryDto> GetCustomerSummary(int CustomerId, CancellationToken cancellationToken)
        => await _customerService.GetCustomerSummary(CustomerId, cancellationToken);

    public async Task<bool> Register(Customer customer, CancellationToken cancellationToken)
        => await _customerService.Register(customer, cancellationToken);

    public async Task UpdateProfile(CustomerSummaryDto customerSummary, CancellationToken cancellationToken)
        => await _customerService.UpdateProfile(customerSummary, cancellationToken);
    #endregion
}
