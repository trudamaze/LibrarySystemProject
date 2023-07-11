using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface ILibrary
    {
        void AddBook(string bookName, string bookAuthor, string ISBN, double rentingPriceInDollars);
        List<Book> GetAllBooks();
        int GetNumberOfCopies(Book book);
        void BorrowBook(Book book, string borrowersName, DateTime startDate, DateTime currentDate);
        void ReturnBook(Book book, string borrowersName);
        List<Borrowing> GetAllBorrowings();
    }
}
