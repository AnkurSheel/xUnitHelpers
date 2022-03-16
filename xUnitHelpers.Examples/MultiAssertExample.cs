using Xunit;

namespace xUnitHelpers.Examples
{
    public class MultiAssertExample
    {
        [Fact(Skip = "This is a failing test")]
        public void MultiAssertTest()
        {
            var result = 2 + 2;
            AssertHelper.AssertMultiple(() => Xunit.Assert.IsType<double>(result), () => Xunit.Assert.Equal(5, result), () => Xunit.Assert.Equal(4, result));
        }
    }
}
