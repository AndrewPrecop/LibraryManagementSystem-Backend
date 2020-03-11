using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Editure { get; set; }

        public bool Deleted { get; set; }
    }
}
