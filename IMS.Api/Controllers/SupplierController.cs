using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.SupplierService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(ISupplierService _supplierService) : ControllerBase
    {
        [HttpGet("get-all-supplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            var res = await _supplierService.getAllSupplier();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("supplierById/{id}")]
        public async Task<IActionResult> GetSupplierById([FromRoute] int id)
        {
            var res = await _supplierService.getSupplierById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-supplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDto model)
        {
            var obj = new Supplier()
            {
                name = model.name,
                email = model.email,
                phone = model.phone,
                address = model.address
            };
            await _supplierService.AddSupplier(obj);
            return Ok(obj);
        }
    }
}
