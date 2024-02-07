using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;   // mind it we need to take instance of Interface file not for Implementation one

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<List<BookModel>> GetAllBooks()
        {
            var list = await _bookRepository.GetAllBooksAsync();
            return list;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var books = await _bookRepository.AddBookAsync(bookModel);
            return Ok(books);
        }


        [HttpDelete("{Id}")]
        public async Task<List<BookModel>> DeleteBook([FromRoute] int Id)
        {
            var records = _bookRepository.DeleteBook(Id);
            return await records;
        }



    }
}
