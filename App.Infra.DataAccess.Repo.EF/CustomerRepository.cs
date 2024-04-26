using App.Domain.Core.CustomerEntity;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Infra.DB.SQLServer.EF;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            if (customers.Any())
            {
                return customers;
            }
            return null;
        }

        public Customer GetById(int id) => _context.Customers.FirstOrDefault(x => x.Id == id);

        public bool Register(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
