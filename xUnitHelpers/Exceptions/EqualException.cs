using Xunit.Sdk;

namespace xUnitHelpers.Exceptions
{
    public class EqualException<T> : EqualException
    {
        public EqualException(T expected, T actual, string userMessage) : base(expected, actual)
        {
            UserMessage = userMessage;
        }

        public override string Message => UserMessage + "\n" + base.Message;
    }
}
