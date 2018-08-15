using System.Collections.Generic;

namespace NameSorter.App
{
    public interface IWriter
    {
        void Write(IEnumerable<string> names);
    }
}
