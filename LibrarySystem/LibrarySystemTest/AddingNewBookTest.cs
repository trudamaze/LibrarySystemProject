using Microsoft.Extensions.DependencyModel;
using LibrarySystem;
using Library = LibrarySystem.Library;
using LibrarySystem.Errors;

namespace LibrarySystemTest
{
    public class AddingNewBookTest
    {
        ILibrary library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void AddBookWithValidParameters_ReturnsTwoBooks()
        {
            //Arange           
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);
            library.AddBook("The Kite Runner", "Khaled Hosseini", "9233585457741", 120);

            List<Book> allBooks = library.GetAllBooks();
            Assert.AreEqual(allBooks.Count, 2);
        }
        [Test]
        public void AddBookWithInvalidISBN_ReturnsISBNIsTooLongException()
        {
            Assert.Throws<ISBNIsTooLongException>(() => library.AddBook("War and peace", "Lev Tolstoi", "942588596320111111", 58));
        }
        [Test]
        public void AddBookWithACopy_ReturnsOneBookWithTwoCopies()
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            List<Book> books = library.GetAllBooks();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(books.Count, 1);
                Assert.AreEqual(library.GetNumberOfCopies(books[0]), 2);
            });
            

        }
    }
}