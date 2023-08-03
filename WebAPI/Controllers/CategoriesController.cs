using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #region GEtAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAllForHome
        [HttpGet("GetAllForHome")]
        public IActionResult GetAllForHome()
        {
            var result = _categoryService.GetAllForHome();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetById
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetByIdForHome
        [HttpGet("GetByIdForHome/{id}")]
        public IActionResult GetByIdForHome(int id)
        {
            var result = _categoryService.GetByIdForHome(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public  IActionResult Add(CategoryDto category)
        {
            var result = _categoryService.Add(category);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(int id,CategoryDto categorydto)
        {
            var result = _categoryService.Update(id,categorydto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Delete
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
