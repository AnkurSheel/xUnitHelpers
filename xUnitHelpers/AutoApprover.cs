using System;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;

namespace xUnitHelpers
{
    public class AutoApprover : IApprovalFailureReporter
    {
        // ReSharper disable once InconsistentNaming
        public static readonly AutoApprover INSTANCE = new AutoApprover();

        public void Report(string approved, string received)
        {
            var success = ApproveFiles(approved, received);
            Debug.WriteLine(success);
            Console.WriteLine(success);
        }

        private bool ApproveFiles(string approved, string received)
        {
            if (!File.Exists(received))
            {
                return false;
            }

            if (File.Exists(approved))
            {
                File.Delete(approved);
            }

            if (File.Exists(approved))
            {
                return false;
            }

            File.Copy(received, approved);

            return File.Exists(approved);
        }
    }
}
