using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Month
    {
        public int Number {  get; set; }
        public string Name { get; set; }
        public int Days { get; set; }

        public override string ToString()
        {
            return $"{Number}. {Name} - {Days} days";
        }
    }
}
