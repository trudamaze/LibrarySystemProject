using LibrarySystem.Errors;
using LibrarySystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Library : ILibrary
    {
        public Dictionary<Book, int> AllBooks = new Dictionary<Book, int>(); // the value from the dictionary represents the number of copies for a book
        public List<Borrowing> AllBorrowings = new List<Borrowing>();
        void ILibrary.AddBook(string bookName, string bookAuthor, string ISBN, double rentingPriceInDollars)
        {
            if (ISBN.Length > 13) 
            { 
                throw new ISBNIsTooLongException("The ISBN should not be longer than 13 digits."); 
            }

            foreach (var book in AllBooks.Keys.ToList())
            {
                if (book.ISBN == ISBN)
                {
                    AllBooks[book]++;
                    return;
                }
            }

            Book newBook = new(bookName, bookAuthor, ISBN, rentingPriceInDollars);
            AllBooks.Add(newBook, 1);
        }
        List<Book> ILibrary.GetAllBooks()
        {
            List<Book> books = new();

            foreach (var item in AllBooks)
            {
                books.Add(item.Key);
            }

            return books.Distinct().ToList();
        }
        int ILibrary.GetNumberOfCopies(Book book)
        {
            if (AllBooks.ContainsKey(book))
            {
                return AllBooks[book];
            }
            throw new BookNotFoundException();
        }
        void ILibrary.BorrowBook(Book book, string borrowersName, DateTime startDate, DateTime currentDate)
        {
            if (AllBooks.ContainsKey(book))
            {
                if(AllBooks[book] > 0) //checking if all the copies of the book are already borrowed
                {
                    Person person = new Person() { Name = borrowersName };
                    Borrowing borrowing;

                    if ((currentDate - startDate).Days > 14)
                    {
                        TimeSpan exceededPeriod = currentDate - startDate;
                        double penalty = (1 / 100f) * book.RentingPrice * exceededPeriod.Days; // could use Math.Round for fewer decimals
                        person.TotalPenalty += penalty;

                        borrowing = new Borrowing(book, person, startDate, exceededPeriod, penalty);
                    }
                    else
                    {
                        borrowing = new Borrowing(book, person, startDate);
                    }

                    AllBorrowings.Add(borrowing);

                    AllBooks[book]--;
                }
            }
            else
            {
                throw new BookNotFoundException();
            }
            
        }
        void ILibrary.ReturnBook(Book book, string borrowersName)
        {
            
            if (book != null && !String.IsNullOrEmpty(borrowersName))
            {
                if (AllBorrowings.Count > 0)
                {
                    Borrowing borrowing = AllBorrowings.Where(b => b.Person.Name == borrowersName && b.Book == book).FirstOrDefault();
                    if (borrowing != null)
                    {
                        AllBorrowings.Remove(borrowing);

                        AllBooks[book]++;
                    }
                    else throw new BookNotBorrowedException();
                }
                else
                {
                    throw new BookNotBorrowedException();
                }
            }
            else
            {
                throw new InvalidArgumentException();
            }  
        }

        public List<Borrowing> GetAllBorrowings()
        {
            return AllBorrowings;
        }
    }
}
