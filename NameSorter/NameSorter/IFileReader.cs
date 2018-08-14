using System.Collections.Generic;

namespace NameSorter.App
{
    public interface IReader
    {
        List<string> ReadNames(string path);
    }
}
