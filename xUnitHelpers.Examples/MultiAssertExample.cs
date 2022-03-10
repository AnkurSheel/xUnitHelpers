using Xunit;

namespace xUnitHelpers.Examples
{
    public class MultiAssertExample
    {
        [Fact(Skip = "This test has failures. Remove skipping to see how MultiAssert works")]
        public void MultiAssertTest()
        {
            var result = 2 + 2;
            AssertHelper.AssertMultiple(() => Assert.IsType<double>(result),
                                        () => Assert.Equal(5, result),
                                        () => Assert.Equal(4, result));
        }
    }
}
