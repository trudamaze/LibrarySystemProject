using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Person
    {
        //some property for identification, could be auto-generated Id
        public string Name { get; set; } = null!;
        public double? TotalPenalty { get; set; }
    }
}
