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

        public void Run()
        {                       
            var names = _reader.Read();

            var sortedNames = _sorter.Sort(names);

            _writer.Write(sortedNames);
        }
    }
}
