using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(IBrandService _brandService) : ControllerBase
    {
        [HttpGet("get-all-brand")]
        public async Task<IActionResult> GetAllBrand()
        {
            var res =await _brandService.getAllBrand();
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("brandById/{id}")]
        public async Task<IActionResult> GetBrandById([FromRoute] int id)
        {
            var res = await _brandService.getBrandById(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-brand")]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto model)
        {
            var obj = new Brand()
            {
                name = model.name
            };
            await _brandService.AddBrand(obj);
            return Ok(obj);
        }
    }
}
