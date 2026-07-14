using Application.Contract;
using Application.DTOs;
using Infraestructure.Eceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmadoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppServices;
        public CategoryController(ICategoryAppService categoryAppServices)
        {
            _categoryAppServices = categoryAppServices;
        }
        [Route("api/[controller]/CreateCategory")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryDto dto)
        {
            try
            {
                var newCategory = _categoryAppServices.AddCategory(dto);
                return Ok(newCategory);

            }
            catch (AlreadyExistsException e)
            {

                return BadRequest(e);
            }
        }
        [Route("api/[controller]/GetAllCategory")]
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categories = _categoryAppServices.GetAllCategory();
            return Ok(categories);
        }

        [Route("api/[controller]/GetCategoryById/{id}")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var Category = _categoryAppServices.GetCategoryById(id);
            return Ok(Category);
        }
        [Route("api/[controller]/UpdateCategory")]
        [HttpPut]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDto dto)
        {
            var UpdateCategory = _categoryAppServices.UpdateCategory(id, dto);
            if (UpdateCategory == null)
            {
                return BadRequest("El registro no pudo ser modificado");
            }
            return Ok(UpdateCategory);
        }
        [Route("api/[controller]/SoftDelete")]
        [HttpDelete]
        public IActionResult SoftDelete(int id)
        {
            var category = _categoryAppServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("La Categoria no existe en la base de datos");
            }
            _categoryAppServices.SoftDelete(id);
            return Ok(category);
        }
        [Route("api/[controller]/DeleteCategory")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryAppServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _categoryAppServices.DeleteCategory(id);
            return Ok(new { message = "El registro fue borrado correctamente" });
        }
        [Route("api/[controller]/getCategoryWithCondition")]
        [HttpGet]
        public IActionResult getCategoryWithCondition()
        {
            var ListCategory = _categoryAppServices.GetCategoryNotDeleted();
            return Ok(ListCategory);
        }
    }
}
