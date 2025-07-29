using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.BrandService;
using IMS.Service.Services.ProductCategoryService;
using IMS.Service.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _productService, IProductCategoryService _productCategoryService, IBrandService _brandService) : ControllerBase
    {
        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProduct()
        {
            var res = await _productService.getAllProduct();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("productById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var res = await _productService.getProductById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto model)
        {
            var res = await _productCategoryService.getProductCategoryByName(model.category_name);
            if (res == null)
            {
                return NotFound("No Category_found");
            }
            var res1 = await _brandService.getBrandByName(model.brand_name);
            if (res1 == null)
            {
                return NotFound("No Brand Found");
            }
            var obj = new Product()
            {
                name = model.name,
                description = model.description,
                category_id = res.id,
                brand_id = res1.id,
                unit_cost = model.unit_cost,
            };
            await _productService.AddProduct(obj);
            return Ok(obj);
        }


    }
}
