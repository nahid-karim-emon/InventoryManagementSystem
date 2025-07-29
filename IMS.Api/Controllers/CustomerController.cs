using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService _customerService) : ControllerBase
    {
        [HttpGet("get-all-customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var res = await _customerService.getAllCustomer();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("customerById/{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var res = await _customerService.getCustomerById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto model)
        {
            var obj = new Customer()
            {
                name = model.name,
                email = model.email,
                phone = model.phone,
                address = model.address
            };
            await _customerService.AddCustomer(obj);
            return Ok(obj);
        }
    }
}
