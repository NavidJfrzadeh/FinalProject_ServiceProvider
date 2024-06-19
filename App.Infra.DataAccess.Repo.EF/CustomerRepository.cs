using App.Domain.Core.CustomerEntity;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.CustomerEntity.DTOs;
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
        public async Task<List<CustomerListDto>> GetAll(CancellationToken cancellationToken)
        {
            var customers = await _context.Customers.AsNoTracking().Select(c => new CustomerListDto
            {
                CustomerId = c.Id,
                FullName = c.FullName,
                ProfileImage = c.ProfileImageUrl
            }).ToListAsync(cancellationToken);

            return customers ?? new List<CustomerListDto>();
        }

        public async Task<Customer> GetById(int id, CancellationToken cancellationToken)
        {
            var customer = await FindById(id, cancellationToken);
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

        public async Task<CustomerSummaryDto> GetCustomerSummary(int CustomerId, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(c => c.Id == CustomerId)
                .Select(c => new CustomerSummaryDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ProfileImage = c.ProfileImageUrl,
                    Email = c.ApplicationUser.Email,
                    PhoneNumber = c.ApplicationUser.PhoneNumber
                }).FirstOrDefaultAsync(cancellationToken);

            return customer ?? throw new Exception($"Profile not found for CustomerID {CustomerId}");
        }

        public async Task UpdateProfile(CustomerSummaryDto customerSummary, CancellationToken cancellationToken)
        {
            var customer = await FindById(customerSummary.Id, cancellationToken);
            customer.FirstName = customerSummary.FirstName;
            customer.LastName = customerSummary.LastName;
            customer.ProfileImageUrl = customerSummary.ProfileImage;
            customer.Addresses = customerSummary.Addresses;

            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Private Fields
        public async Task<Customer> FindById(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(id, cancellationToken);

            return customer ?? throw new Exception($"Customer with Id {id} not found");
        }
        #endregion
    }
}
