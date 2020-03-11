using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IBooksRepository booksRepository;

        public PeopleController(IPeopleRepository peopleRepository, IBooksRepository booksRepository)
        {
            this.peopleRepository = peopleRepository;
            this.booksRepository = booksRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var person = peopleRepository.GetById(id);

            return Ok(person);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var people = peopleRepository.GetAll();

            return Ok(people);
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            peopleRepository.AddPerson(person);

            return Ok(person);
        }


        [HttpPost("{personId}/borrow/{bookId}")]
        public IActionResult BorrowBook(Guid personId, Guid bookId)
        {
            peopleRepository.BorrowBook(peopleRepository.GetById(personId), booksRepository.GetById(bookId));

            return Ok(1);
        }

        [HttpPost("{personId}/return/{bookId}")]
        public IActionResult ReturnBook(Guid personId, Guid bookId)
        {
            peopleRepository.ReturnBook(peopleRepository.GetById(personId), booksRepository.GetById(bookId));

            return Ok(1);
        }


    }
}
