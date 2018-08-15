using NameSorter.App.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Implementations
{
    public class LinqSorter<T> : ISorter<T>
    {
        private readonly IComparer<T> _comparer;

        public LinqSorter(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public List<T> Sort(IEnumerable<T> input)
        {
            return input.OrderBy(i => i, _comparer)
                .ToList();            
        }
    }
}
