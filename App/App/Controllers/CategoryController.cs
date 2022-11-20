using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Category;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace App.Controllers
{
    public class CategoryController : AppController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
                _categoryService= categoryService;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto category)
        {
            await _categoryService.CreateAsync(category);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);

                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete([Required] int id)
        {
            try
            {
                await _categoryService.SoftDeleteAsync(id);

                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, CategoryUpdateDto category)
        {
            try
            {
                await _categoryService.UpdateAsync(id, category);

                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Search(string? search)
        {
            return Ok(await _categoryService.SearchAsync(search));
        }


    }
}
