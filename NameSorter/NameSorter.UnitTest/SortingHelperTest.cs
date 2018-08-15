using NameSorter.App.Helpers;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.UnitTest
{
    public class SortingHelperTest
    {
        [Fact]
        public void ShouldSwapCorrectly()
        {
            var input = new List<int>
            {
                0,1,2,3,4,5,6,7,8,9
            };

            var expected = new List<int>
            {
                1,0,2,3,4,5,6,7,8,9
            };

            input.Swap(0, 1).ShouldBe(expected);
            input.ShouldBe(expected);
        }
    }
}
