using NameSorter.App.Config;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.App
{
    public class FileWriter : IWriter
    {
        private readonly OutputPath _outputPath;

        public FileWriter(OutputPath outputPath)
        {
            _outputPath = outputPath;
        }

        public void Write(List<string> names)
        {
            var consoleWriter = new ConsoleWriter();
            consoleWriter.Write(names);

            File.WriteAllLines(_outputPath.Value, names);
        }
    }
}
