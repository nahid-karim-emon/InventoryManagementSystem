using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.ProductCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController (IProductCategoryService _productCategoryService) : ControllerBase
    {
        [HttpGet("all-productCategory")]
        public async Task<IActionResult> GetAllProductCategory()
        {
            var res = await _productCategoryService.getAllProductCategory();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("getProductCategoryById/{id}")]

        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id)
        {
            var res = await _productCategoryService.getProductCategoryById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-productCategory")]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryDto model)
        {
            var obj = new ProductCategory()
            {
                name = model.name,
                description = model.description
            };
            await _productCategoryService.AddProductCategory(obj);
            return Ok(obj);
        }
    }
}
