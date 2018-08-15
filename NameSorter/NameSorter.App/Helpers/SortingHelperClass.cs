using System.Collections.Generic;

namespace NameSorter.App.Helpers
{
    public static class SortingHelperClass
    {
        public static List<T> Swap<T>(this List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;

            return list;
        }
    }
}
