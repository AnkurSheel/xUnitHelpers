# Auto Approver

## Usage

In `ApprovalTestConfig.cs` add the following snippet

```csharp
using xUnitHelpers;

[assembly: UseReporter(typeof(AutoApprover))]
```

### Result

This will automatically approve the the test but in your test runner it will show up as a failing test so that you have a clear indication of which tests failed.
