using System.Collections.Generic;

namespace NameSorter.App
{
    public interface IWriter
    {
        void WriteNames(string path, List<string> names);
    }
}
