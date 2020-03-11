using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Repositories;

namespace Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext context;
        private readonly IHistoricRepository historicRepository;

        public BooksRepository(AppDbContext context, IHistoricRepository historicRepository)
        {
            this.context = context;
            this.historicRepository = historicRepository;
        }

        public void AddBook(Book book)
        {
            this.context.Books.Add(book);

            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, BookId = book.Id, EventType = EventType.AddBook });

            context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, BookId = book.Id, EventType = EventType.DeleteBook });

            book.Deleted = true;

            EditBook(book);
        }

        public void EditBook(Book book)
        {
            var dbBook = GetById(book.Id);

            if (dbBook != null)
            {
                this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, BookId = book.Id, EventType = EventType.EditBook });

                dbBook.Author = book.Author;
                dbBook.Editure = book.Editure;
                dbBook.Title = book.Title;
                dbBook.Deleted = book.Deleted;

                context.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, EventType = EventType.SearchBook });

            return context.Books.Where(w => !w.Deleted).ToList();
        }

        public Book GetById(Guid id)
        {
            var book = context.Books.Where(w => !w.Deleted).FirstOrDefault(f => f.Id == id);

            this.historicRepository.AddHistoricItem(new HistoricItem { Date = DateTime.Now, BookId = book.Id, EventType = EventType.SearchBook });

            return book;
        }
    }
}
