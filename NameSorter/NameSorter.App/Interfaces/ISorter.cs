using System.Collections.Generic;

namespace NameSorter.App.Interfaces
{
    public interface ISorter<T>
    {
        List<T> Sort(IEnumerable<T> input);
    }
}
