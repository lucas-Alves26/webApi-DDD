using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Product;

namespace WebApi.Areas.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _product.Create(product);

            return Created("", product);
        }
    }
}
