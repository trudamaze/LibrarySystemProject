using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Exceptions
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException()
        {
        }
        public InvalidArgumentException(string? message) : base(message)
        {
        }
    }
}
