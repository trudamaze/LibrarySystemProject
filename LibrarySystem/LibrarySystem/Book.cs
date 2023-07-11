using LibrarySystem.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Book
    {
        public string Name { get; private set; } = null!;
        public string Author { get; private set; } = null!;
        public string ISBN { get; private set; } = null!;
        public double RentingPrice { get; private set; }
        private Book()
        {
        }
        public Book(string name, string author, string isbn, double rentingPrice)
        {
            this.Name = name;
            this.Author = author;
            this.ISBN = isbn;
            this.RentingPrice = rentingPrice;
        }
        public Book GetBook() 
        {
            Book book = new Book() { Name= this.Name, ISBN= this.ISBN, RentingPrice= this.RentingPrice };

            return book;
        }
    }
}
