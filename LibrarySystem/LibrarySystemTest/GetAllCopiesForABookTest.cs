using LibrarySystem;
using LibrarySystem.Exceptions;

namespace LibrarySystemTest
{
    internal class GetAllCopiesForABookTest
    {
        ILibrary library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }
        [Test]
        public void GetAllCopiesOfExistingBook_ReturnsInt()
        {
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);
            library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

            List<Book> books = library.GetAllBooks();

            Assert.AreEqual(library.GetNumberOfCopies(books[0]), 3);

        }
        [Test]
        public void GetAllCopiesOfInexistentBook_ReturnsBookNotFoundException()
        {
            Book book = new Book("War and peace", "Lev Tolstoi", "9425885963201", 58);

            Assert.Throws<BookNotFoundException>(() => library.GetNumberOfCopies(book));
        }
    }
}
