using LibrarySystem;
using LibrarySystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemTest
{
    internal class ReturnBookTest
    {
        ILibrary library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }
        [Test]
        public void ReturnBorrowedBook_ReturnOk()
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Book book = library.GetAllBooks().Where(b => b.ISBN == "9425885963201").First();

            library.BorrowBook(book, "Eduard", new DateTime(2023, 06, 20), new DateTime(2023, 06, 24));

            var bookCopiesAfterBorrowing = library.GetNumberOfCopies(book);

            library.ReturnBook(book, "Eduard");

            var bookCopiesAfterReturning = library.GetNumberOfCopies(book);

            Assert.That(bookCopiesAfterReturning == bookCopiesAfterBorrowing +1);
        }
        [Test]
        public void ReturnBookThatWasNotBorrowed_ReturnBookNotBorrowedException()
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Book book = library.GetAllBooks().Where(b => b.ISBN == "9425885963201").First();
 
            Assert.Throws<BookNotBorrowedException>(() => library.ReturnBook(book, "Eduard"));
        }
    }
}
