using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.App
{
    public interface INameSorterService
    {
        void Run(string inputPath, string outputPath);
    }
}
