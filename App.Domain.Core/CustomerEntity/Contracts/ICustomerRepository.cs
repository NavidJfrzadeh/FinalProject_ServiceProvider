namespace App.Domain.Core.CustomerEntity.Contracts
{
    public interface ICustomerRepository
    {
        public Customer GetById(int id);
        public List<Customer> GetAll();
        public bool Register(Customer customer);
    }
}
