# Compare Collections In Order

## Usage

```csharp
 public class AssertOrderedCollection
    {
        [Fact]
        public void If_content_matches_test_passes()
        {
            var expectedList = new List<int> { 1, 2, 3 };

            var actualList = new List<int> { 1, 2, 3};

            AssertHelper.AssertOrderedCollection(expectedList, actualList);
        }
```


More examples of usage can be found in the [Examples project](https://github.com/AnkurSheel/xUnitHelpers/blob/master/xUnitHelpers.Examples/AssertOrderedCollection.cs).
