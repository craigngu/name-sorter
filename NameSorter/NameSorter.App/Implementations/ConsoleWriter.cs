using System;
using System.Collections.Generic;

namespace NameSorter.App.Implementations
{
    public class ConsoleWriter : IWriter
    {
        public void Write(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
