# Custom Error Message

Currently, we support custom error messages for 
1. Assert.Equal
2. Assert.Contains

## Usage

```csharp
[Fact]
public void AssertCustomErrorMessagesTest()
{
   Assert.Contains(expected, actual, "custom error message")
   Assert.Equal(expected, actual, "custom error message")
}
```
