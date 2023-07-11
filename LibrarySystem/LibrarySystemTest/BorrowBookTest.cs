using LibrarySystem;
using LibrarySystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemTest
{
    internal class BorrowBookTest
    {
        ILibrary library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }
        [Test]
        public void BorrowBookFromLibrary_BookCopiesFromLibraryDecrease() 
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Book book = library.GetAllBooks().Where(b => b.ISBN == "9425885963201").First();

            library.BorrowBook(book, "Eduard", new DateTime(2023, 06, 20), new DateTime(2023, 06, 24));

            List<Book> allBooks = library.GetAllBooks();

            Assert.That(library.GetNumberOfCopies(allBooks[0]) == 0);

        }
        [Test]
        public void BorrowInexistentBookFromLibrary_ReturnBookNotFoundException()
        {
            Book book = new Book("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Assert.Throws<BookNotFoundException>(() => library.BorrowBook(book, "Eduard", new DateTime(2023, 06, 20), new DateTime(2023, 06, 24)));
        }
        [Test]
        public void BorrowBookForMoreThanTwoWeeks_ReturnPenalty()
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Book book = library.GetAllBooks().Where(b => b.ISBN == "9425885963201").First();

            var startDate = new DateTime(2023, 06, 01);
            var currentDate = new DateTime(2023, 06, 24);
            library.BorrowBook(book, "Eduard", startDate, currentDate);

            double penalty = (1 / 100f) * book.RentingPrice * (currentDate-startDate).Days;

            Assert.AreEqual(library.GetAllBorrowings().Where(b => b.Person.Name == "Eduard" && b.Book == book).First().Penalty, penalty);

        }
    }
}
