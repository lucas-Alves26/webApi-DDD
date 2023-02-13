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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadCategoryDto>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var category = await _category.Get();

                if (category != null)
                {
                    var readCategoryDto = _mapper.Map<List<ReadCategoryDto>>(category);
                    return Ok(readCategoryDto);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadCategoryDto))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _category.GetById(id);

                if (category != null)
                {
                    var readcategoryDto = _mapper.Map<ReadCategoryDto>(category);
                    return Ok(readcategoryDto);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadCategoryDto))]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                category.DateRegister= DateTime.Now;
                await _category.Create(category);
                var readCategory = _mapper.Map<ReadCategoryDto>(category);

                return Created(nameof(GetById), new { category.Id, readCategory });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = await _category.GetById(categoryDto.Id);

                if (category != null)
                {
                    _mapper.Map(categoryDto, category);
                    category.DateUpdate = DateTime.Now;  
                    await _category.Update(category);
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _category.GetById(id);

                if (category == null)
                    return NotFound();

                await _category.Delete(category);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
