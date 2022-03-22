using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


using AybitCase.Service;
using AybitCase.command;
using AybitCase.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace AybitCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("FirstCors")]
    public class CustomerController : Controller
    {
        public static CreateCustomerCommand customer = new CreateCustomerCommand();
        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //register
        [HttpPost("create")]
        public async Task<IActionResult> Register(CreateCustomerCommand command)
        {
            //var customer = new CreateCustomerCommand
            //{
            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;
            customer.Email = command.Email;
            customer.Password = BCrypt.Net.BCrypt.HashPassword(command.Password);
            //};
            bool isSuccess = await _customerService.Create(command);
            if (isSuccess)
                return Ok();
            //return Created("success", await _customerService.Create(customer));
            return BadRequest();

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginCustomerCommand command)
        {
            bool isSuccess = await _customerService.Login(command);
            if (isSuccess)
            {
                //return Ok();
                string token = CreateToken(command);
                Console.WriteLine("TEST");
                Console.WriteLine(token);
                return Ok(token);
            }
                
            return BadRequest();

        }

        // [HttpPost("update")]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(UpdateCustomerCommand command)
        {
            bool isSuccess = await _customerService.Update(command);
            if (isSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isSuccess = await _customerService.Delete(id);
            if (isSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            
            return Ok(customers);
        }

        private string CreateToken(LoginCustomerCommand command)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, command.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
