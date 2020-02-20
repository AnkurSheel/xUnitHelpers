using Xunit;

namespace xUnitHelpers.Examples
{
    public class PrimitiveTestData
    {
        public string ToString(int value)
        {
            return $"{value}";
        }

        public string ToStringAndAppendCats(int value)
        {
            return $"{value} Cats";
        }
    }

    public class JsonFileDataAttributeExamples
    {
        [Theory]
        [JsonFileData("allDataPrimitive.json", typeof(int), typeof(string))]
        public void WholeFileAsSourceForTheoryTests_PrimitiveTypes_ToString(int data, string expected)
        {
            var test = new PrimitiveTestData();
            var result = test.ToString(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("dataPrimitive.json", "ToString", typeof(int), typeof(string))]
        public void MultipleTheoryTestsInSingleFile_PrimitiveTypes_ToString(int data, string expected)
        {
            var test = new PrimitiveTestData();
            var result = test.ToString(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("dataPrimitive.json", "ToStringAndAppendCats", typeof(int), typeof(string))]
        public void MultipleTheoryTestsInSingleFile_PrimitiveTypes_ToStringAndAppendCats(int data, string expected)
        {
            var test = new PrimitiveTestData();
            var result = test.ToStringAndAppendCats(data);
            Assert.Equal(expected, result);
        }
    }
}