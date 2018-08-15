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
                    if(_comparer.Compare(list[i], list[i+1]) > 0)
                    {
                        Swap(list, i, i + 1);
                        changed = true;
                    }
                }
            }

            return list;
        }

        private void Swap(List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
