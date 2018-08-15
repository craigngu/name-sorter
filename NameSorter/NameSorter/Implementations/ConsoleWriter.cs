using System;
using System.Collections.Generic;

namespace NameSorter.App.Implementations
{
    public class ConsoleWriter : IWriter
    {
        public void Write(IEnumerable<string> names)
        {
            foreach (var line in names)
            {
                Console.WriteLine(line);
            }
        }
    }
}
