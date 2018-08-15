using NameSorter.App.Config;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.App.Implementations
{
    public class FileWriter : IWriter
    {
        private readonly OutputPath _outputPath;

        public FileWriter(OutputPath outputPath)
        {
            _outputPath = outputPath;
        }

        public void Write(IEnumerable<string> names)
        {
            File.WriteAllLines(_outputPath.Value, names);
        }
    }
}
