using Library.Business.Abstract;
using Library.Entities.Concrete;
using Library.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var bookList = _bookService.GetAll();
            if (bookList.Count == 0)
            {
                return BadRequest("Hata lan Hata");
            }
            return Ok(bookList);
        }

        [HttpPost("Add")]
        public IActionResult Add(BookAddDto bookAddDto)
        {
            if (bookAddDto == null)
            {
                return BadRequest("Nereye Sallıyon");
            }
            var addedbook = _bookService.Add(bookAddDto);
            return Ok(addedbook);
        }

        [HttpPost("AddAlternative")]
        public IActionResult AddAlternative(BookAddDto bookAddDto)
        {
            if (bookAddDto == null)
            {
                return BadRequest("Nereye Sallıyon");
            }
            var addedbook = _bookService.AddAlternative(bookAddDto);
            return Ok(addedbook);
        }

        [HttpPost("Update")]
        public IActionResult Update(Book book)
        {
            if (book == null)
            {
                return BadRequest("Nereye Sallıyon");
            }
            var updatedbook = _bookService.Update(book);
            return Ok(updatedbook);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Book book)
        {
            if (book == null)
            {
                return BadRequest("Nereye Sallıyon");
            }
            var deletedbook = _bookService.Delete(book);
            return Ok(deletedbook);
        }
    }
}
