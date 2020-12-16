using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using xUnitHelpers.Moq;

namespace xUnitHelpers.Examples.Moq
{
    public class VerifyLoggingExamples
    {
        private readonly Mock<ILogger<TestClassForVerifyLogging>> _mockLogger;
        private readonly TestClassForVerifyLogging _sut;

        public VerifyLoggingExamples()
        {
            _mockLogger = new Mock<ILogger<TestClassForVerifyLogging>>();
            _sut = new TestClassForVerifyLogging(_mockLogger.Object);
        }

        [Fact]
        public void VerifySingleLog()
        {
            _sut.SingleLog();

            _mockLogger.VerifyLog("Error Message");
        }


        [Fact]
        public void VerifyMultipleLogsOfSameType()
        {
            _sut.MultipleLogsOfSameType();

            _mockLogger.VerifyLog("Error Message one")
                       .VerifyLog("Error Message two")
                       .VerifyLog("Error Message three");
        }

        [Fact]
        public void VerifySameLogMultipleTimes()
        {
            _sut.SameLogMultipleTimes();

            _mockLogger.VerifyLog("Error Message", times: Times.Exactly(3));
        }


        [Fact]
        public void VerifyMultipleLogsOfDifferentTypes()
        {
            _sut.MultipleLogsOfDifferentTypes();

            _mockLogger.VerifyLog("Error Message")
                       .VerifyLog("Warning Message", LogLevel.Warning)
                       .VerifyLog("Debug Message", LogLevel.Debug);
        }
    }
}