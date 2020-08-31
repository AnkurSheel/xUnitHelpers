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

        private string _approved;
        private string _received;

        public void Report(string approved, string received)
        {
            _approved = approved;
            _received = received;
            var success = ApproveFiles();
            Debug.WriteLine(success);
            Console.WriteLine(success);
        }

        public bool ApproveFiles()
        {
            if (!File.Exists(_received))
            {
                return false;
            }

            if (File.Exists(_approved))
            {
                File.Delete(_approved);
            }

            if (File.Exists(_approved))
            {
                return false;
            }

            File.Copy(_received, _approved);

            return File.Exists(_approved);
        }
    }
}