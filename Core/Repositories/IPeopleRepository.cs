using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IPeopleRepository
    {
        List<Person> GetAll();
        Person GetById(Guid id);
        void AddPerson(Person person);
        void ReturnBook(Person person, Book book);
        void BorrowBook(Person person, Book book);
    }
}
