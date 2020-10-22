# Verify Calls to Ilogger using Moq

## Usage

Create a Mock Logger. The variable name can be anything, buts lets assume that the name is `_loggerMock` for the purpose of the examples.

### Verify single call to LogError

```csharp
_loggerMock.VerifyLogging("Error Message");
```

### Verify multiple calls to LogError

```csharp
_loggerMock.VerifyLogging("Error Message one")
            .VerifyLogging("Error Message two")
            .VerifyLogging("Error Message three");
```

### Verify multiple calls to the same LogError

```csharp
_loggerMock.VerifyLogging("Error Message", times: Times.Exactly(3));
```

### Verify calls to different log levels

```csharp
_loggerMock.VerifyLogging("Error Message")
            .VerifyLogging("Warning Message", LogLevel.Warning)
            .VerifyLogging("Debug Message", LogLevel.Debug);
```

More examples of usage can be found in the [Examples project](https://github.com/AnkurSheel/xUnitHelpers/blob/master/xUnitHelpers.Examples/Moq/VerifyLoggingExamples.cs).
