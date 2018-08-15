using NameSorter.App.Helpers;
using NameSorter.App.Implementations;
using NameSorter.App.Models;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NameSorter.UnitTest
{
    public class BubbleSorterTest
    {
        [Fact]
        public void ShouldSortNumbersCorrectly()
        {
            var input = new List<int> { 1, 3, 2, 1, 1, 3, 2, 5, 6, 7 };
            var output = new List<int> { 1, 1, 1, 2, 2, 3, 3, 5, 6, 7 };
            new BubbleSorter<int>(Comparer<int>.Default)
                .Sort(input)
                .ShouldBe(output);
        }

        [Fact]
        public void ShouldSortTheExampleCorrectly()
        {
            new BubbleSorter<Person>(new PersonNameComparer())
                .Sort(exampleInput.Select(i => new Person(i)))
                .Select(p => p.Name)
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
