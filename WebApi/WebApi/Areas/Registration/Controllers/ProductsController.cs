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
        public async Task<IActionResult> Get()
        {
            var produto = await _product.Get();

            if (produto != null)
                return Ok(produto);

            return NotFound();
        }

        [HttpGet("{id}")]
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                await _product.Update(product);

                return Created(nameof(GetById), new { Id = product.Id, product });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _product.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
