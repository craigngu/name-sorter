using NameSorter.App.Models;
using Shouldly;
using System;
using Xunit;

namespace NameSorter.UnitTest
{
    public class PersonNameTest
    {
        [Theory]
        [InlineData("Janet Parsons", "Janet", "Parsons")]
        [InlineData("Vaughn Lewis", "Vaughn", "Lewis")]
        [InlineData("Adonis Julius Archer", "Adonis Julius", "Archer")]
        [InlineData("Shelby Nathan Yoder", "Shelby Nathan", "Yoder")]
        [InlineData("Marin Alvarez", "Marin", "Alvarez")]
        [InlineData("London Lindsey", "London", "Lindsey")]
        [InlineData("Beau Tristan Bentley", "Beau Tristan", "Bentley")]
        [InlineData("Leo Gardner", "Leo", "Gardner")]
        [InlineData("Hunter Uriah Mathew Clarke", "Hunter Uriah Mathew", "Clarke")]
        [InlineData("Mikayla Lopez", "Mikayla", "Lopez")]
        [InlineData("Frankie Conner Ritter", "Frankie Conner", "Ritter")]
        public void ShouldHaveCorrectFirstAndLastNames(string name, string firstName, string lastName)
        {
            var person = new Person(name);
            person.FirstName.ShouldBe(firstName);
            person.LastName.ShouldBe(lastName);
        }

        [Theory]
        [InlineData("Janet")]
        [InlineData("")]
        [InlineData("Frankie Conner Ritter Lopez Clarke")]
        public void InvalidNameShouldThrowError(string name)
        {
            Should.Throw(() => new Person(name), typeof(Exception));
        }
    }
}
