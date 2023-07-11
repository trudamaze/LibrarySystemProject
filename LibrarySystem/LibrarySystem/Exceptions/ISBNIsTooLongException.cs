using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Errors
{
    public class ISBNIsTooLongException : Exception
    {
        public ISBNIsTooLongException()
        {
        }
        public ISBNIsTooLongException(string? message) : base(message)
        {           
        }
    }
}
