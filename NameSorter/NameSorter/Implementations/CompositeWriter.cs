using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace NameSorter.App.Implementations
{
    public class CompositeWriter : IWriter
    {
        private readonly IEnumerable<IWriter> _writers;

        public CompositeWriter(IEnumerable<IWriter> writers)
        {
            _writers = writers;
        }

        public void Write(IEnumerable<string> names)
        {
            foreach (var writer in _writers)
            {
                writer.Write(names);
            }
        }
    }
}
