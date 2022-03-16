using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Sdk;

namespace xUnitHelpers
{
    public static class AssertHelper
    {
        private static readonly string LineBreakForFailure = $"{Environment.NewLine}*******{Environment.NewLine}{Environment.NewLine}";

        public static void AssertMultiple(params Action[] assertionsToRun)
        {
            var failures = GetFailures(assertionsToRun);

            if (failures.Any())
            {
                var errorText = GetErrorMessage(failures);

                throw new XunitException(
                    $"{failures.Count}/{assertionsToRun.Length} conditions failed:{Environment.NewLine}{Environment.NewLine}{errorText}{Environment.NewLine}{LineBreakForFailure}");
            }
        }

        public static void AssertUnorderedCollection<T>(IReadOnlyCollection<T> expected, IReadOnlyCollection<T> actual)
        {
            var failures = new List<Exception>();
            GetFailure(() => Assert.Equal(expected.Count, actual.Count, "Number of Elements in collections do not match"), failures);

            foreach (var value in expected)
            {
                GetFailure(() => Assert.Contains(value, actual, "Element missing from collection"), failures);
            }

            foreach (var value in actual)
            {
                GetFailure(() => Assert.Contains(value, expected, "Extra Element in collection"), failures);
            }

            if (failures.Any())
            {
                var errorText = GetErrorMessage(failures);

                throw new XunitException($"{errorText}{LineBreakForFailure}");
            }
        }

        public static void AssertOrderedCollection<T>(IReadOnlyCollection<T> expected, IReadOnlyCollection<T> actual)
        {
            var failures = new List<Exception>();

            GetFailure(() => Assert.Equal(expected.Count, actual.Count, "Number of Elements in collections do not match"), failures);

            for (var i = 0; i < expected.Count && i < actual.Count; i++)
            {
                var expectedElement = expected.ElementAt(i);
                var actualElement = actual.ElementAt(i);

                var index = i;
                GetFailure(() => Assert.Equal(expectedElement, actualElement, $"Element does not match at index {index}"), failures);
            }

            if (failures.Any())
            {
                var errorText = GetErrorMessage(failures);

                throw new XunitException($"{errorText}{LineBreakForFailure}");
            }
        }

        private static void GetFailure(Action assertion, List<Exception> errorMessages)
        {
            var failures = GetFailures(
                new List<Action>
                {
                    assertion
                });

            if (failures.Any())
            {
                errorMessages.Add(failures[0]);
            }
        }

        private static IReadOnlyList<Exception> GetFailures(IReadOnlyCollection<Action> assertionsToRun)
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

            return errorMessages;
        }

        private static string GetErrorMessage(IReadOnlyList<Exception> failures)
        {
            var errorText = new StringBuilder();

            foreach (var e in failures)
            {
                if (errorText.Length > 0)
                {
                    errorText.Append(LineBreakForFailure);
                }

                errorText.Append(RemoveBoringLinesFromStackTrace(e));
            }

            return errorText.ToString();
        }

        private static object? RemoveBoringLinesFromStackTrace(Exception e)
        {
            if (e.StackTrace == null)
            {
                return null;
            }

            var sb = new StringBuilder(e.Message).AppendLine();

            foreach (var line in e.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                // don't report uninteresting stack trace lines.
                if (line.Contains("Xunit.Assert") || line.Contains("AssertHelper.AssertMultiple") || line.Contains("AssertHelper.GetFailure") || line.Contains("xUnitHelpers.Assert"))
                {
                    continue;
                }

                sb.AppendLine(line);
            }

            return sb;
        }
    }
}
