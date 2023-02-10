using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using WebApi.Dto.Category;

namespace WebApi.Areas.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategory _category;
        private IMapper _mapper;
        public CategorysController(ICategory category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryDto);
                await _category.Create(category);
                return Created(nameof(GetById), new { category.Id, category });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCategoryDto))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _category.GetById(id);
                _mapper.Map<CreateCategoryDto>(category);

                if (category != null)
                    return Ok(category);

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
