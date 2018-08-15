using NameSorter.App.Helpers;
using NameSorter.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Implementations
{
    public class LinqSorter : INameSorter
    {
        private readonly IComparer<Person> _comparer;

        public LinqSorter(IComparer<Person> comparer)
        {
            _comparer = comparer;
        }

        public List<string> Sort(IEnumerable<string> names)
        {
            return names.Select(n => new Person(n))
                .OrderBy(p => p, _comparer)
                .Select(p => p.Name)
                .ToList();
        }
    }
}
