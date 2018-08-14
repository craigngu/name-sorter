using NameSorter.App.Config;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.App
{
    public class FileReader : IReader
    {
        private readonly InputPath _inputPath;

        public FileReader(InputPath inputPath)
        {
            _inputPath = inputPath;
        }

        public List<string> Read()
        {
            return File.ReadAllLines(_inputPath.Value).ToList();
        }
    }
}
