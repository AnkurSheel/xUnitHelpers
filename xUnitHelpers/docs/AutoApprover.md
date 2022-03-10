# Auto Approver

## Usage

In `ApprovalTestConfig.cs` add the following snippet

```csharp
using xUnitHelpers;

[assembly: UseReporter(typeof(AutoApprover))]
```

## Result

It will automatically update the the approval file. But, in the test runner it will show up as a failing test so that we have a clear indication of which tests failed.

It will not do anything if the received and approved files match so if we run the test again (without changing anything), it will pass.
