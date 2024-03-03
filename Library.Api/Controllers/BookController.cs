using Library.Business.Contracts;
using Library.Entities.MongoDB.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookDetailAsync(string id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetBookDetailAsync()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        [HttpPost("save")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookDto model)
        {
            var result = await _bookService.CreateAsync(model);
            if (!result) return BadRequest("Book creating failed");

            return Created();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookDto model)
        {
            var result = await _bookService.UpdateAsync(model);
            if (!result) return BadRequest("Book updating failed");
            return Ok(result);
        }
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result=  await _bookService.DeleteAsync(id);
            if (!result) return BadRequest("Book deleting failed");
            return Ok(result);
        }

    }
}
