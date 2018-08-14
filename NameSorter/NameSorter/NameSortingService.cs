using System;

namespace NameSorter.App
{
    public class NameSorterService : INameSorterService
    {
        private readonly IReader _reader;
        private readonly INameSorter _sorter;
        private readonly IWriter _writer;

        public NameSorterService(IReader reader, INameSorter sorter, IWriter writer)
        {
            _reader = reader;
            _sorter = sorter;
            _writer = writer;
        }

        public void Run(string inputPath, string outputPath)
        {                       
            var names = _reader.ReadNames(inputPath);

            var sortedNames = _sorter.Sort(names);

            var consoleWriter = new ConsoleWriter();
            consoleWriter.WriteNames(names);

            _writer.WriteNames(outputPath, sortedNames);
        }
    }
}
