using NameSorter.App.Helpers;
using NameSorter.App.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Implementations
{
    public class BubbleSorter<T> : ISorter<T>
    {
        private readonly IComparer<T> _comparer;

        public BubbleSorter(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public List<T> Sort(IEnumerable<T> input)
        {
            var list = input.ToList();

            var changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < list.Count() - 1; i++)
                {
                    bool isOutOfOrder = _comparer.Compare(list[i], list[i + 1]) > 0;
                    if (isOutOfOrder)
                    {
                        list.Swap(i, i + 1);
                        changed = true;
                    }
                }
            }

            return list;
        }        
    }
}
