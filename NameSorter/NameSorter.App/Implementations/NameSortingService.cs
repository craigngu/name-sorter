using Microsoft.Extensions.Logging;
using System;

namespace NameSorter.App.Implementations
{
    public class NameSorterService : INameSorterService
    {
        private readonly IReader _reader;
        private readonly INameSorter _sorter;
        private readonly IWriter _writer;
        private readonly ILogger<NameSorterService> _logger;

        public NameSorterService(IReader reader, INameSorter sorter, IWriter writer, ILogger<NameSorterService> logger)
        {
            _reader = reader;
            _sorter = sorter;
            _writer = writer;
            _logger = logger;
        }

        public void Run()
        {
            try
            {
                var names = _reader.Read();
                var sortedNames = _sorter.Sort(names);
                _writer.Write(sortedNames);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

        }
    }
}
