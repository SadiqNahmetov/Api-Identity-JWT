using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Product;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace App.Controllers
{
    public class BookController : AppController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto book)
        {
            await _bookService.CreateAsync(book);
            return Ok();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [Authorize(Roles = "Menber")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);

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
                await _bookService.SoftDeleteAsync(id);

                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookUpdateDto book)
        {
            try
            {
                await _bookService.UpdateAsync(id, book);

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
            return Ok(await _bookService.SearchAsync(search));
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int id)
        {
            return Ok(await _bookService.GetById(id));
        }
    }
}
