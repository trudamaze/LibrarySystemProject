using LibrarySystem;

ILibrary Library = new Library();

//adding books to the library, even multiple copies for one
Library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);
Library.AddBook("The Kite Runner", "Khaled Hosseini", "9233585457741", 120);
Library.AddBook("War and peace", "Lev Tolstoi", "9425885963201", 58);

//getting all the books from the library
List<Book> books = Library.GetAllBooks();

foreach (Book book in books)
{
    Console.WriteLine(book.Name + " - " + book.ISBN);
}

//getting the number of copies for some of the books
Console.WriteLine($"Number of copies for {books[0].Name} is {Library.GetNumberOfCopies(books[0])}.");
Console.WriteLine($"Number of copies for {books[1].Name} is {Library.GetNumberOfCopies(books[1])}.");

//borrowing a book 
//I will provide dummy data for StartDate and for a period shorter or longer than 2 weeks in order to test functionality
//StartDate whould be DateTime.Now and Period should be calculated automatically if we had a database
Library.BorrowBook(books[1], "John", new DateTime(2023, 06, 20), new DateTime(2023, 06, 24));
Library.BorrowBook(books[0], "Ricardo", new DateTime(2023, 06, 01), new DateTime(2023, 06, 24));

Console.WriteLine("The penalty for Ricardo is " + Library.GetAllBorrowings().Where(b => b.Person.Name == "Ricardo" && b.Book == books[1]).First().Penalty);


//return a borrowed book
