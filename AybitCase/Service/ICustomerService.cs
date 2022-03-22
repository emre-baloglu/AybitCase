using AybitCase.Models;
using AybitCase.command;

namespace AybitCase.Service
{
    public interface ICustomerService
    {
        Task<bool> Create(CreateCustomerCommand command);
        Task<bool> Update(UpdateCustomerCommand command);
        Task<bool> Login(LoginCustomerCommand command);
        // Task<bool> Delete(DeleteCustomerCommand command);
        Task<bool> Delete(int? id = 0);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetByEmail(string email);
        Task<Customer> GetByPassword(string password);
    }
}
