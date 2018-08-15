using NameSorter.App.Models;
using System.Collections.Generic;

namespace NameSorter.App.Helpers
{
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.LastName != y.LastName
                ? x.LastName.CompareTo(y.LastName)
                : x.FirstName.CompareTo(y.FirstName);
        }
    }
}
