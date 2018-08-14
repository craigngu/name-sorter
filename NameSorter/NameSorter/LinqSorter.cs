using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    public class LinqSorter : INameSorter
    {
        public List<string> Sort(IEnumerable<string> names)
        {
            return names.OrderBy(l => GetLastName(l))
                        .ThenBy(l => GetFirstNames(l))
                        .ToList();
        }

        private static string GetFirstNames(string name)
        {
            var names = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var firstNames = names.Take(names.Count() - 1);

            return string.Join(" ", firstNames);
        }

        private static string GetLastName(string name)
        {
            return name.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();
        }
    }
}
