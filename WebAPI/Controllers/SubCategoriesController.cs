﻿using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _subCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAllWithBaseCategory
        [HttpGet("GetAllWithBaseCategory")]
        public IActionResult GetAllWithBaseCategory()
        {
            var result = _subCategoryService.GetAllWithBaseCategory();
            if(result.Success)
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
            var result = _subCategoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetByIdWithBaseCategory
        [HttpGet("GetByIdWithBaseCategory/{id}")]
        public IActionResult GetByIdWithBaseCategory(int id)
        {
            var result = _subCategoryService.GetByIdWithBaseCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]    
        public IActionResult Add( SubCategoryDto subCategory)
        {
            var result = _subCategoryService.Add(subCategory);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update/{id}")]
        public IActionResult Update(SubCategory subCategory)
        {
            var result = _subCategoryService.Update(subCategory);
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
            var result = _subCategoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
   