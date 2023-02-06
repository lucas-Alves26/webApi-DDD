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

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
           var produto = await _product.GetById(id);

            if(produto != null)
                return Ok(produto);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                await _product.Create(product);

                return Created(nameof(GetById), new { Id = product.Id, product });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);     
            }

        }


    }
}
