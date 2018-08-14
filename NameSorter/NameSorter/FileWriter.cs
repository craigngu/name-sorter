using System.Collections.Generic;

namespace NameSorter.App
{
    public class FileWriter : IWriter
    {
        public void WriteNames(string path, List<string> names)
        {
            System.IO.File.WriteAllLines(path, names);
        }
    }
}
