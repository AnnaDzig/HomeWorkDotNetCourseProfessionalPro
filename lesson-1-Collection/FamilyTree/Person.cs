using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    internal class Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public List<Person> Descendants
        { get; set; } = new List<Person>();

        public void AddDescendant(Person descendant)
        { Descendants.Add(descendant); }
        public void RemoveDescendant(string name) 
        { Descendants.RemoveAll(d => d.Name == name); }
        public IEnumerable< Person> GetDescendants()
        {
        return Descendants;
        }
        public IEnumerable<Person> GetDescendantsByYear(int year)
            { return Descendants.Where(d => d.YearOfBirth == year); }
        public override string ToString()
        {
                return $"{Name} {YearOfBirth}";
            }
        }
    }
