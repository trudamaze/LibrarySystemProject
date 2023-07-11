using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Exceptions
{
    public class BookNotBorrowedException : Exception
    {
        public BookNotBorrowedException()
        {
        }
        public BookNotBorrowedException(string? message) : base(message)
        {
        }
    }
}
