using AybitCase.Repository;
using AybitCase.Models;
using AybitCase.command;


namespace AybitCase.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<bool> Create(CreateCustomerCommand command)
        {
            // to-do 
            //CHECK if customer already exists with token

            bool IsCustomerExist = await _customerRepository.IsCustomerExistWithEmail(command.Email);
            if (IsCustomerExist)
            {
                return false;
            }

            var domain = new Customer(command.FirstName, command.LastName, command.Email, command.Password);
            bool isSuccess = await _customerRepository.Create(domain);
            return isSuccess;
        }

        public async Task<bool> Login(LoginCustomerCommand command)
        {
            bool IsCustomerExist = await _customerRepository.IsCustomerExistWithEmail(command.Email);
            if (!IsCustomerExist)
            {
                return false;
            }


            bool isSuccess = await _customerRepository.Login(command);
            return isSuccess;

        }

        public async Task<bool> Update(UpdateCustomerCommand command)
        {
            // to-do 
            //CHECK if customer already exists with name

            bool IsCustomerExist = await _customerRepository.IsCustomerExistWithId(command.Id);
            if (!IsCustomerExist)
            {
                return false;
            }

            var domain = new Customer(command.Id, command.FirstName, command.LastName, command.Email, command.Password);
            bool isSuccess = await _customerRepository.Update(domain);
            return isSuccess;
        }
        public async Task<bool> Delete(int? id = 0)
        {
            // to-do 
            //CHECK if customer exists with id

            var IsCustomerExist = await _customerRepository.IsCustomerExistWithId(id);
            if (!IsCustomerExist)
            {
                return false;
            }

            bool isSuccess = await _customerRepository.Delete(id);
            return isSuccess;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            //to-do  MAP View Model.
            return customers;
        }

        public async Task<Customer> GetByEmail(string email)
        {
            var IsCustomerExist = await _customerRepository.GetByEmail(email);
            Console.WriteLine(IsCustomerExist);

            return IsCustomerExist;
        }

        public async Task<Customer> GetByPassword(string email)
        {
            var user = await _customerRepository.GetByPassword(email);

            Console.WriteLine(user);

            return user;
        }
    }
}
