using NameSorter.App;
using NameSorter.App.Implementations;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.UnitTest
{
    public class CompositeWriterTest
    {
        [Fact]
        public void ShouldCallAllWritersOnceEach()
        {
            var writer1 = Substitute.For<IWriter>();
            var writer2 = Substitute.For<IWriter>();
            var writer3 = Substitute.For<IWriter>();
            var writer = new CompositeWriter(new List<IWriter> { writer1, writer2, writer3 });

            writer.Write(exampleOutput);

            writer1.Received(1).Write(exampleOutput);
            writer2.Received(1).Write(exampleOutput);
            writer3.Received(1).Write(exampleOutput);
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
