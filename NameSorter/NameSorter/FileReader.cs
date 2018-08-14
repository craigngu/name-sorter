using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App
{
    public class FileReader : IReader
    {
        public List<string> ReadNames(string path)
        {
            return System.IO.File.ReadAllLines(path).ToList();
        }
    }
}
