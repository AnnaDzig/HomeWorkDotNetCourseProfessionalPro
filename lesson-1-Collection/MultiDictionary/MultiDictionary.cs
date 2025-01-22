using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDictionary
{
    internal class MultiDict
    {
        private List<WordEntry> dictionary = new List<WordEntry>();
        public void AddWord(string ukrainian, string danish, string english)

        {
            dictionary.Add(new WordEntry(ukrainian, danish, english));

        }
        public string? FindDanish(string ukrainian)
        {
            return dictionary.FirstOrDefault(w => w.Ukrainian == ukrainian)?.Danish;
        }
        public string? FindEnglish(string ukrainian)
        {
            return dictionary.FirstOrDefault(w => w.Ukrainian == ukrainian)?.English;
        }
        public void PrintAll()
        {
            foreach (var entry in dictionary)
            {
                Console.WriteLine(entry);
            }
        }
    }
}