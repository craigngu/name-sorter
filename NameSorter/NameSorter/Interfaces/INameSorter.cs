using System.Collections.Generic;

namespace NameSorter.App
{
    public interface INameSorter
    {
        List<string> Sort(IEnumerable<string> names);
    }
}
