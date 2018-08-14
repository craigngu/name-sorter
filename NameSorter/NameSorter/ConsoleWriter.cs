using System;
using System.Collections.Generic;

namespace NameSorter.App
{
    public class ConsoleWriter
    {
        public void WriteNames(List<string> names)
        {
            foreach (var line in names)
            {
                Console.WriteLine(line);
            }
        }
    }
}
