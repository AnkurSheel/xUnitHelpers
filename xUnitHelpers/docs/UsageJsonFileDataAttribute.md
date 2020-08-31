# Loading test data from a JSON file for xUnit Tests

## Usage

The entire file provides the data

```json
[
    {
        "data": 1,
        "result": "1"
    },
    {
        "data": 2,
        "result": "2"
    }
]
```

The file contains data for multiple theory tests

```json
{
    "propertyName1": [
        {
            "data": 1,
            "result": "1"
        },
        {
            "data": 2,
            "result": "2"
        }
    ],
    "propertyName2": [
        {
            "data": 1,
            "result": "1 1"
        },
        {
            "data": 2,
            "result": "2 2"
        }
    ]
}
```

```csharp
[Theory]
[JsonFileData("path/to/json/file", "propertyName1", typeof(int), typeof(string))]
public void FileAsSourceForMultipleTests1(int data, string expected)
{
     var test = new SUT();
     var result = test.TestFunctiondata);
     Assert.Equal(expected, result);
}

[Theory]
[JsonFileData("path/to/json/file", "propertyName2", typeof(int), typeof(string))]
public void FileAsSourceForMultipleTests2(int data, string expected)
{
     var test = new SUT();
     var result = test.TestFunctiondata);
     Assert.Equal(expected, result);
}
```

More examples of usage can be found in the
[Examples project](https://github.com/AnkurSheel/xUnitHelpers/blob/master/xUnitHelpers.Examples/JsonFileDataAttributeExamples.cs)
