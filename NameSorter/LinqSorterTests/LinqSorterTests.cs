using NameSorter;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LinqSorterTests
{
    public class LinqSorterTests
    {
        [Fact]
        public void ShouldSortTheExampleCorrectly()
        {
            new LinqSorter().Sort(exampleInput)
                .ShouldBe(exampleOutput);
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
