using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LibraryApiLinux.Models;
using LibraryApiLinux.Services;
using LibraryApiLinux.dtos;
using AutoMapper;

namespace LibraryApiLinux.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IWebApiRepo repository;
        private readonly IMapper mapper;

        // Constructor fixes: Correct assignment of the injected IMapper
        public BooksController(IWebApiRepo repo, IMapper map)
        {
            repository = repo;
            mapper = map;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            var booklist = repository.GetAllBooks();
            return Ok(mapper.Map<IEnumerable<BookReadDto>>(booklist));
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BookReadDto>(book));
        }

        [HttpPost]
        public ActionResult<Book> AddBook(BookWriteDto b)
        {
            var book = mapper.Map<Book>(b);
            repository.AddBook(book);
            repository.SaveChanges();
            return CreatedAtRoute(nameof(GetBookById), new { Id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDto b)
        {
            var bookInRepo = repository.GetBookById(id);
            if (bookInRepo == null)
            {
                return NotFound();
            }
            mapper.Map(b, bookInRepo);
            repository.UpdateBook(bookInRepo);
            repository.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteBook(int id)
        { 
            var book = repository.GetBookById(id); 
            if (book == null)
            {
                return NotFound(); 
            }
            repository.DeleteBook(book);
            repository.SaveChanges();
            return Ok();
        }
    }

}