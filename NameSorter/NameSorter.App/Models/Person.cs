using NameSorter.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Models
{
    public class Person
    {
        private readonly List<string> _nameParts;

        public Person(string name)
        {
            Name = name;
            _nameParts = name.ToNameParts();
            ValidateNamePartCount();
        }        

        private void ValidateNamePartCount()
        {
            if (_nameParts.Count < 2 || _nameParts.Count > 4)
            {
                throw new Exception($"{Name} is not a valid name");
            }
        }

        public string Name { get; }

        public string LastName => _nameParts.Last();

        public string FirstName => string.Join(" ", GetFirstNames());                  

        private IEnumerable<string> GetFirstNames()
        {
            return _nameParts.Take(_nameParts.Count() - 1);
        }
    }
}
