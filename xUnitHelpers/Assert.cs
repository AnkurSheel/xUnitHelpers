using System.Collections.Generic;
using Xunit.Sdk;
using xUnitHelpers.Exceptions;

namespace xUnitHelpers
{
    public static class Assert
    {
        public static void Equal<T>(T expected, T actual, string userMessage)
        {
            try
            {
                Xunit.Assert.Equal(expected, actual);
            }
            catch (EqualException)
            {
                throw new EqualException<T>(expected, actual, userMessage);
            }
        }

        public static void Contains<T>(T expectedValue, IReadOnlyCollection<T> collection, string userMessage)
        {
            try
            {
                Xunit.Assert.Contains(expectedValue, collection);
            }
            catch (ContainsException)
            {
                throw new ContainsException<T>(expectedValue, collection, userMessage);
            }
        }
    }
}
