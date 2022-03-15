using System.Collections.Generic;
using Xunit.Sdk;

namespace xUnitHelpers.Exceptions
{
    public class ContainsException<T> : ContainsException
    {
        public ContainsException(T expectedValue, IReadOnlyCollection<T> collection, string userMessage) : base(expectedValue, collection)
        {
            UserMessage = userMessage;
        }

        public override string Message => UserMessage + "\n" + base.Message;
    }
}
