namespace App.Domain.Core.CustomerEntity.Contracts
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(int id, CancellationToken cancellationToken);
        public Task<List<Customer>> GetAll(CancellationToken cancellationToken);
        public Task<bool> Register(Customer customer, CancellationToken cancellationToken);
    }
}
