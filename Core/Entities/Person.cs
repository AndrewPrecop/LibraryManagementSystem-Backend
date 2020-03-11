using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Book> BorrowedBooks { get; set; }
    }
}
