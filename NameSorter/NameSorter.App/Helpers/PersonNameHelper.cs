using NameSorter.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Helpers
{
    public static class PersonNameHelper
    {
        public static List<string> ToNameList(this IEnumerable<Person> personList)
        {
            return personList.Select(p => p.Name).ToList();
        }

        public static List<Person> ToPersonList(this IEnumerable<string> names)
        {
            return names.Select(n => new Person(n)).ToList();
        }

        public static List<string> ToNameParts(this string name)
        {
            return name.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
