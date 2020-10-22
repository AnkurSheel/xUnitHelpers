using Microsoft.Extensions.Logging;

namespace xUnitHelpers.Examples.Moq
{
    public class TestClassForVerifyLogging
    {
        private readonly ILogger<TestClassForVerifyLogging> _logger;

        public TestClassForVerifyLogging(ILogger<TestClassForVerifyLogging> logger)
        {
            _logger = logger;
        }

        public void SingleLog()
        {
            _logger.LogError("Error Message");
        }

        public void SameLogMultipleTimes()
        {
            for (var i = 0; i < 3; i++)
            {
                _logger.LogError("Error Message");
            }
        }

        public void MultipleLogsOfSameType()
        {
            _logger.LogError("Error Message one");
            _logger.LogError("Error Message two");
            _logger.LogError("Error Message three");
        }

        public void MultipleLogsOfDifferentTypes()
        {
            _logger.LogDebug("Debug Message");
            _logger.LogWarning("Warning Message");
            _logger.LogError("Error Message");
        }
    }
}