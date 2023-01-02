using Microsoft.AspNetCore.Mvc;
using ProjeAPI.Core.API;
using ProjeAPI.Core.Entities;
using ProjeAPI.Core.Enums.Errors;
using ProjeAPI.Core.RepositoryConcrete;
using ProjeAPI.Core.Services;


namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerProcess
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(Product), (int)HttpCodes.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> AddProduct(AddProductService newProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _productService.AddProduct(newProduct);
            return this.ProccessResult(res);
        }
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> GetAllProducts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _productService.GetAllProducts();
            return this.ProccessResult(res);
        }
    }
}
