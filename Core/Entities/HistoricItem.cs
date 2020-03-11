using System;

namespace Core.Entities
{
    public class HistoricItem
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public EventType EventType { get; set; }

        public Guid? BookId { get; set; }

        public Guid? PersonId { get; set; }
    }

    public enum EventType { AddBook, EditBook, DeleteBook, AddPerson, BorrowBook, ReturnBook, SearchBook, SearchPerson };
}
