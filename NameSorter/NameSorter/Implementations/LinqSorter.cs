using NameSorter.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App.Implementations
{
    public class LinqSorter : INameSorter
    {
        public List<string> Sort(IEnumerable<string> names)
        {
            return names.Select(n => new Person(n))
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Select(p => p.Name)
                .ToList();            
        }        
    }
}
