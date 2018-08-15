using NameSorter.App.Helpers;
using NameSorter.App.Models;
using Shouldly;
using Xunit;

namespace NameSorter.UnitTest
{
    public class PersonNameComparerTest
    {
        [Theory]
        [InlineData("Janet Parsons", "Janet Parsons", 0)]
        [InlineData("Adonis Julius Archer", "Adonis Julius Archer", 0)]
        [InlineData("Hunter Uriah Mathew Clarke", "Hunter Uriah Mathew Clarke", 0)]
        [InlineData("Marin Alvarez", "Janet Parsons", -1)]
        [InlineData("Marin Alvarez", "Leo Gardner", -1)]
        [InlineData("Beau Tristan Bentley", "Shelby Nathan Yoder", -1)]
        [InlineData("Frankie Conner Ritter", "Janet Parsons", 1)]
        [InlineData("Mikayla Lopez", "Hunter Uriah Mathew Clarke", 1)]
        [InlineData("Janet Parsons", "Marin Alvarez", 1)]
        public void PersonNameComparerShouldCompareCorrectly(string firstPerson, string secondPerson, int result)
        {
            var comparer = new PersonNameComparer();

            Person first = new Person(firstPerson);
            Person second = new Person(secondPerson);
            comparer.Compare(first, second).ShouldBe(result);
        }
    }
}
