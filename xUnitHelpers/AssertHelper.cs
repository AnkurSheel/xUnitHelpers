using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

namespace xUnitHelpers
{
    public class AssertHelper
    {
        public static void AssertMultiple(params Action[] assertionsToRun)
        {
            var errorMessages = new List<Exception>();
            foreach (var action in assertionsToRun)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception exc)
                {
                    errorMessages.Add(exc);
                }
            }

            if (errorMessages.Count <= 0)
            {
                return;
            }

            var errorText = new StringBuilder();
            foreach (var e in errorMessages)
            {
                if (errorText.Length > 0)
                {
                    errorText.Append(Environment.NewLine);
                }

                errorText.Append(RemoveBoringLinesFromStackTrace(e));
            }

            throw new XunitException(
                $"{errorMessages.Count}/{assertionsToRun.Length} conditions failed:{Environment.NewLine}{Environment.NewLine}{errorText}{Environment.NewLine}{Environment.NewLine}*******{Environment.NewLine}{Environment.NewLine}");
        }

        private static object RemoveBoringLinesFromStackTrace(Exception e)
        {
            var sb = new StringBuilder(e.Message).AppendLine();

            foreach (var line in e.StackTrace.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
            {
                // don't report uninteresting stack trace lines.
                if (line.Contains("Xunit.Assert") || line.Contains("AssertHelper.AssertMultiple"))
                {
                    continue;
                }

                sb.AppendLine(line);
            }

            return sb;
        }
    }
}