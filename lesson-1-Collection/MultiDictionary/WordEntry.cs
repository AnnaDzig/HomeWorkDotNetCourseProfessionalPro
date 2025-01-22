using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDictionary
{
    internal class WordEntry
    {
        public string Ukrainian { get; }
        public string Danish { get; }
        public string English { get; }

        public WordEntry(string ukrainian, string danish, string english)
        {
            Ukrainian = ukrainian;
            Danish = danish;
            English = english;
        }
        public override string ToString()
        {
            return $" Ukrainian: {Ukrainian}, Danish: {Danish}, English {English}";
        }
    }
}