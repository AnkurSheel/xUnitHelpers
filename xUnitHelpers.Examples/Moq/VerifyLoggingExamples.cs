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

            _loggerMock.VerifyLog("Error Message");
        }


        [Fact]
        public void VerifyMultipleLogsOfSameType()
        {
            _sut.MultipleLogsOfSameType();

            _loggerMock.VerifyLog("Error Message one")
                       .VerifyLog("Error Message two")
                       .VerifyLog("Error Message three");
        }

        [Fact]
        public void VerifySameLogMultipleTimes()
        {
            _sut.SameLogMultipleTimes();

            _loggerMock.VerifyLog("Error Message", times: Times.Exactly(3));
        }


        [Fact]
        public void VerifyMultipleLogsOfDifferentTypes()
        {
            _sut.MultipleLogsOfDifferentTypes();

            _loggerMock.VerifyLog("Error Message")
                       .VerifyLog("Warning Message", LogLevel.Warning)
                       .VerifyLog("Debug Message", LogLevel.Debug);
        }
    }
}