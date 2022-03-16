using System.Collections.Generic;
using Xunit;

namespace xUnitHelpers.Examples
{
    public class AssertOrderedCollection
    {
        [Fact]
        public void If_content_matches_test_passes()
        {
            var expectedList = new List<int>
            {
                1,
                2,
                3
            };

            var actualList = new List<int>
            {
                1,
                2,
                3
            };

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }

        [Fact(Skip = "This is a failing test")]
        public void If_content_does_not_match_in_order_test_fails()
        {
            var expectedList = new List<int>
            {
                1,
                2,
                2,
                3
            };

            var actualList = new List<int>
            {
                1,
                2,
                3,
                2
            };

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }

        [Fact(Skip = "This is a failing test")]
        public void If_content_does_not_match_test_fails()
        {
            var expectedList = new List<int>
            {
                1,
                2,
                4,
            };

            var actualList = new List<int>
            {
                1,
                2,
                3
            };

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }

        [Fact(Skip = "This is a failing test")]
        public void If_expected_has_more_elements_test_fails()
        {
            var expectedList = new List<int>
            {
                1,
                2,
                3,
                4
            };

            var actualList = new List<int>
            {
                1,
                2,
                3,
            };

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }

        [Fact(Skip = "This is a failing test")]
        public void If_actual_has_more_elements_test_fails()
        {
            var expectedList = new List<int>
            {
                1,
                2,
                3,
            };

            var actualList = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }
    }
}
