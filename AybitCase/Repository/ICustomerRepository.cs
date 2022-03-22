using AybitCase.command;
using AybitCase.Models;


namespace AybitCase.Repository
{
    public interface ICustomerRepository
    {
        //Task<bool> IsCustomerExistWithName(string customerName, int? id = 0);
        Task<bool> IsCustomerExistWithEmail(string email);
        Task<bool> IsCustomerExistWithId(int? id = 0);
        Task<bool> Create(Customer customer);
        Task<bool> Update(Customer customer);
        //Task<bool> Login(Customer domain);
        // Task<bool> Delete(Customer customer);
        Task<bool> Delete(int? id = 0);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetByEmail(string email);
        Task<Customer> GetByPassword(string password);
        Task<bool> Login(LoginCustomerCommand command);
    }
}

