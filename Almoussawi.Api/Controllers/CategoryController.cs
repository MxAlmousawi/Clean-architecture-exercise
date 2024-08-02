using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository.Interfaces;

namespace Almoussawi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string category)
        {
            await categoryRepository.Add(category);
            return Ok(category);
        }

        [HttpDelete]
        [Route("{category}")]
        public async Task<IActionResult> Delete([FromRoute] string category)
        {
            var cat = await categoryRepository.Delete(category);
            if (cat == null)
            {
                return NotFound("category not found");
            }
            return Ok(category);
        }
    }
}
