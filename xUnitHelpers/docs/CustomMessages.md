# Custom Error Message

Currently, we support custom error messages for 
1. Assert.Equal
2. Assert.Contains

## Usage

```csharp
[Fact]
public void AssertCustomErrorMessagesTest()
{
   AssertX.Contains(expected, actual, "custom error message")
   AssertX.Equal(expected, actual, "custom error message")
}
```
