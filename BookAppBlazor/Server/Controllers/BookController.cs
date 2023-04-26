using BookAppBlazor.Server.Services;
using BookAppBlazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BookAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook ibook;

        public BookController(IBook ibook)
        {
            this.ibook = ibook;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            List<Book> list = await ibook.GetBooks();
            if (list.Count <= 0)
                return NoContent();

            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            Book book = await ibook.GetBook(id);
            if (book != null)
                return Ok(book);

            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, Book book)
        {
            if (id != book.IdBook)
            {
                return BadRequest();
            }
            await ibook.UpdateBook(book);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Book>>PostBook(Book book)
        {
            await ibook.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.IdBook }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeletePerson(int id)
        {
            Book p = await ibook.GetBook(id);
            if (p == null)
                return NotFound();

            await ibook.DeleteBook(id);
            return Ok(p);
        }
    }
}
