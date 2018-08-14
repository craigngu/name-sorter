using System.Collections.Generic;

namespace NameSorter
{
    public interface INameSorter
    {
        List<string> Sort(IEnumerable<string> names);
    }
}
