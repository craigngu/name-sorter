using Microsoft.Extensions.Logging;
using NameSorter.App;
using NameSorter.App.Implementations;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.UnitTest
{
    public class NameSorterServiceTest
    {
        [Fact]
        public void ShouldCallReadSortAndWriteOnce()
        {
            var reader = Substitute.For<IReader>();
            var sorter = Substitute.For<INameSorter>();
            var writer = Substitute.For<IWriter>();
            var logger = Substitute.For<ILogger<NameSorterService>>();

            reader.Read().ReturnsForAnyArgs(exampleInput);
            sorter.Sort(Arg.Any<IEnumerable<string>>()).ReturnsForAnyArgs(exampleOutput);

            var service = new NameSorterService(reader, sorter, writer, logger);
            service.Run();

            reader.Received(1).Read();
            sorter.Received(1).Sort(exampleInput);
            writer.Received(1).Write(exampleOutput);
            logger.DidNotReceive().LogError(Arg.Any<string>());
        }

        private static readonly List<string> exampleInput = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer",
            "Shelby Nathan Yoder",
            "Marin Alvarez",
            "London Lindsey",
            "Beau Tristan Bentley",
            "Leo Gardner",
            "Hunter Uriah Mathew Clarke",
            "Mikayla Lopez",
            "Frankie Conner Ritter"
        };

        private static readonly List<string> exampleOutput = new List<string>
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
            "Leo Gardner",
            "Vaughn Lewis",
            "London Lindsey",
            "Mikayla Lopez",
            "Janet Parsons",
            "Frankie Conner Ritter",
            "Shelby Nathan Yoder"
        };
    }
}
