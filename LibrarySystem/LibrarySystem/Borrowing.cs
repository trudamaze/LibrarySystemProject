using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Borrowing
    {
        public Book Book { get; set; }
        public Person Person { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan? ExceededPeriod { get; set; }
        public double? Penalty { get; set; }
        public Borrowing()
        {
        }
        public Borrowing(Book book, Person person, DateTime startDate)
        {
            this.StartDate = startDate;
            this.Book = book;
            this.Person = person;
        }
        public Borrowing(Book book, Person person, DateTime startDate, TimeSpan exceededPeriod, double penalty)
        {
            this.Book = book;
            this.Person = person;
            this.StartDate = startDate;
            this.ExceededPeriod = exceededPeriod;
            this.Penalty = penalty;
        }
    }
}
