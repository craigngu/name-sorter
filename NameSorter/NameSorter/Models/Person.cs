using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSorter.App.Models
{
    public class Person
    {
        private readonly List<string> _nameParts;

        public Person(string name)
        {
            Name = name;
            _nameParts = name.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string Name { get; }

        public string FirstName => string.Join(" ", GetFirstNames());

        public string LastName => _nameParts.Last();       

        private IEnumerable<string> GetFirstNames()
        {
            return _nameParts.Take(_nameParts.Count() - 1);
        }
    }
}
