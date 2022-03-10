using System.Collections.Generic;
using Xunit;

namespace xUnitHelpers.Examples
{
    public class AssertUnorderedCollection
    {
        [Fact]
        public void AssertUnorderedCollectionTest()
        {
            var expectedList = new List<int>()
            {
                1,
                2,
                3
            };

            var actualList = new List<int>()
            {
                2,
                3,
                1
            };

            AssertHelper.AssertUnorderedCollection(expectedList, actualList);
        }
    }
}
