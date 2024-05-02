using App.Domain.Core.CustomerEntity;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctors
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);
            if (customers.Any())
            {
                return customers;
            }
            return new List<Customer>();
        }

        public async Task<Customer> GetById(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (customer != null)
            {
                return customer;
            }
            return new Customer();
        }

        public async Task<bool> Register(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion

        #region Private Fields
        public async Task<Customer> FindById(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(id, cancellationToken);
            if (customer != null)
            {
                return customer;
            }
            throw new Exception($"Customer with Id {id} not found");
        }
        #endregion
    }
}
