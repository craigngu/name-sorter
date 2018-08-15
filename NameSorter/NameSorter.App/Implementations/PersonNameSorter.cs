using NameSorter.App.Interfaces;
using NameSorter.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Implementations
{
    public class PersonNameSorter : INameSorter
    {
        private readonly ISorter<Person> _sorter;

        public PersonNameSorter(ISorter<Person> sorter)
        {
            _sorter = sorter;
        }

        public List<string> Sort(IEnumerable<string> names)
        {
            return _sorter.Sort(names.Select(n => new Person(n)))
                .Select(p => p.Name)
                .ToList();
        }
    }
}
