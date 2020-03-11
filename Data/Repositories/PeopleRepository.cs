using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext context;
        private readonly IHistoricRepository historicRepository;

        public PeopleRepository(AppDbContext context, IHistoricRepository historicRepository)
        {
            this.context = context;
            this.historicRepository = historicRepository;
        }

        public void AddPerson(Person person)
        {
            context.People.Add(person);

            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, PersonId = person.Id, EventType = EventType.AddPerson });

            context.SaveChanges();
        }

        public void BorrowBook(Person person, Book book)
        {
            var dbPerson = GetById(person.Id);

            if (dbPerson != null)
            {
                if (dbPerson.BorrowedBooks == null)
                    dbPerson.BorrowedBooks = new List<Book>();

                if (dbPerson.BorrowedBooks.Count < 3)
                {
                    this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, PersonId = person.Id, BookId = book.Id, EventType = EventType.BorrowBook });

                    dbPerson.BorrowedBooks.Add(book);

                    context.SaveChanges();
                }
            }
        }

        public List<Person> GetAll()
        {
            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, EventType = EventType.SearchPerson });

            return context.People.Include( i => i.BorrowedBooks).ToList();
        }

        public Person GetById(Guid id)
        {
            var person = context.People.Include(i => i.BorrowedBooks).FirstOrDefault(f => f.Id == id);

            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, PersonId = person.Id, EventType = EventType.SearchPerson });

            return person;
        }

        public void ReturnBook(Person person, Book book)
        {
            var dbPerson = GetById(person.Id);

            if (dbPerson != null)
            {
                if (dbPerson.BorrowedBooks == null)
                    dbPerson.BorrowedBooks = new List<Book>();

                if (dbPerson.BorrowedBooks.Contains(book))
                {
                    this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, PersonId = person.Id, BookId = book.Id, EventType = EventType.ReturnBook });

                    dbPerson.BorrowedBooks.Remove(book);

                    context.SaveChanges();
                }
            }
        }
    }
}
