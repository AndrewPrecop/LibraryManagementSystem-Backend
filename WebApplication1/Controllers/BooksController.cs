using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var person = booksRepository.GetById(id);

            return Ok(person);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var people = booksRepository.GetAll();

            return Ok(people);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]Book book)
        {
            booksRepository.AddBook(book);

            return Ok(1);
        }

        [HttpPut]
        public IActionResult EditBook([FromBody]Book book)
        {
            booksRepository.EditBook(book);

            return Ok(1);
        }

        [HttpDelete]
        public IActionResult DeleteBook([FromBody]Book book)
        {
            booksRepository.DeleteBook(book);

            return Ok(1);
        }

    }
}
