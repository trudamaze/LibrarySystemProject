using LibrarySystem;

namespace LibrarySystemTest
{
    internal class GetAllBooksFromLibrary
    {
        ILibrary library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void GetAllBooksFromLibrary_ReturnsBooks()
        {                     
            Book book = new Book("War and peace", "Lev Tolstoi", "9425885963201", 58);

            library.AddBook(book.Name, book.Author, book.ISBN, book.RentingPrice);

            List<Book> allBooks = library.GetAllBooks();

            Assert.Multiple(() =>
            {
                Assert.That(allBooks[0].Name == book.Name);
                Assert.That(allBooks[0].Author == book.Author);
                Assert.That(allBooks[0].ISBN == book.ISBN);
                Assert.That(allBooks[0].RentingPrice == book.RentingPrice);
            });
            
        }
        [Test]
        public void GetAllBooksFromEmptyLibrary_ReturnsZero()
        {
            Assert.AreEqual(library.GetAllBooks().Count, 0);
        }
    }
}
