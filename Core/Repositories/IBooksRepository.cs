using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IBooksRepository
    {
        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);
        List<Book> GetAll();
        Book GetById(Guid id);
    }
}
