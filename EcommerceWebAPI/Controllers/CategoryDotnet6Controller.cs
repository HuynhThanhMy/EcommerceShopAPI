using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebAPI.Models;
using EcommerceWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using EcommerceWebAPI.Helpers;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDotnet6Controller : ControllerBase
    {
        private readonly ICategoryRepository _bookRepo;
        private readonly MyDbContext _context;

        public CategoryDotnet6Controller(ICategoryRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> AddNewBook(CategoryModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(model);
                var book = await _bookRepo.GetBookAsync(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] CategoryModel model)
        {
            if (id != model.CategoryId)
            {
                return NotFound();
            }
            await _bookRepo.UpdateBookAsync(id, model);
            return Ok();

            //var loai = _context.Categories.SingleOrDefault(lo => lo.CategoryId == id);

            //if (loai == null)
            //{
            //    return NotFound();
            //}
            //await _bookRepo.UpdateBookAsync(model);
            //return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Manager)]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return Ok();
        }
    }
}
