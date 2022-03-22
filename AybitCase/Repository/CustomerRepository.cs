using AybitCase.Models;
using AybitCase.command;
using Microsoft.EntityFrameworkCore;


namespace AybitCase.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCustomerExistWithEmail(string email)
        {
            var customer = await _context.Customers.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (customer != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IsCustomerExistWithId(int? id = 0)
        {
            var customer = await _context.Customers.Where(item => item.Id == id).FirstOrDefaultAsync();
            if (customer != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Login(LoginCustomerCommand customer)
        {
            var domain = await _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefaultAsync();
            if (domain == null)
            {
                return false;
            }

            bool isVerified = BCrypt.Net.BCrypt.Verify(customer.Password, domain.Password);
            if ( isVerified )
            {
                return false;
            }

            
            return true;
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var domain = await _context.Customers.FindAsync(customer.Id);

                domain.FirstName = customer.FirstName;
                domain.LastName = customer.LastName;
                domain.Email = customer.Email;
                domain.Password = customer.Password;
                domain.UpdateDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Delete(int? id = 0)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                // var IsCustomerExist = await _context.Customers.Where(item => item.Id == customer.Id).FirstOrDefaultAsync();
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Customer> GetByPassword(string email)
        {
            return await _context.Customers.FindAsync(email);
        }


    }
}


