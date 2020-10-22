using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using xUnitHelpers.Moq;

namespace xUnitHelpers.Examples.Moq
{
    public class VerifyLoggingExamples
    {
        private readonly Mock<ILogger<TestClassForVerifyLogging>> _loggerMock;
        private readonly TestClassForVerifyLogging _sut;

        public VerifyLoggingExamples()
        {
            _loggerMock = new Mock<ILogger<TestClassForVerifyLogging>>();
            _sut = new TestClassForVerifyLogging(_loggerMock.Object);
        }

        [Fact]
        public void VerifySingleLog()
        {
            _sut.SingleLog();

            _loggerMock.VerifyLogging("Error Message");
        }


        [Fact]
        public void VerifyMultipleLogsOfSameType()
        {
            _sut.MultipleLogsOfSameType();

            _loggerMock.VerifyLogging("Error Message one")
                       .VerifyLogging("Error Message two")
                       .VerifyLogging("Error Message three");
        }

        [Fact]
        public void VerifySameLogMultipleTimes()
        {
            _sut.SameLogMultipleTimes();

            _loggerMock.VerifyLogging("Error Message", times: Times.Exactly(3));
        }


        [Fact]
        public void VerifyMultipleLogsOfDifferentTypes()
        {
            _sut.MultipleLogsOfDifferentTypes();

            _loggerMock.VerifyLogging("Error Message")
                       .VerifyLogging("Warning Message", LogLevel.Warning)
                       .VerifyLogging("Debug Message", LogLevel.Debug);
        }
    }
}