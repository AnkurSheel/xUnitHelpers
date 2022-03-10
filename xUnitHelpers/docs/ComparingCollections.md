# Comparing Collections

## Usage

```csharp
[Fact]
public void AssertUnorderedCollectionTest()
{
    var expectedList = new List<int>() { 1, 2,3 };
    var actualList = new List<int>() {2, 3, 1 };

    AssertHelper.AssertUnorderedCollection(expectedList, actualList);
}
```


More examples of usage can be found in the [Examples project](https://github.com/AnkurSheel/xUnitHelpers/blob/master/xUnitHelpers.Examples/AssertUnorderedCollection.cs).
