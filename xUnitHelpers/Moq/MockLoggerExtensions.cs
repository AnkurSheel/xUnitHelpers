using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace xUnitHelpers.Moq
{
    public static class MockLoggerExtensions
    {
        public static Mock<ILogger<T>> VerifyLog<T>(this Mock<ILogger<T>> logger, string message, LogLevel logLevel = LogLevel.Error, Times? times = null)
        {
            times ??= Times.Once();

            logger.Verify(x => x.Log(It.Is<LogLevel>(level => level == logLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString() == message),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                (Times)times);

            return logger;
        }
    }
}
