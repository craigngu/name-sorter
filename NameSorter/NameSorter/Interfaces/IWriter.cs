using System.Collections.Generic;

namespace NameSorter.App
{
    public interface IWriter
    {
        void Write(List<string> names);
    }
}
