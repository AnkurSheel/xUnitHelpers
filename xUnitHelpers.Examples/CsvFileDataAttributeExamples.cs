using Xunit;

namespace xUnitHelpers.Examples
{
    public class CsvFileDataAttributeExamples
    {
        [Theory]
        [CsvFileData("testData.csv", typeof(DataObject))]
        public void WholeFileAsSourceForTheoryTests_PrimitiveTypes_ToString(DataObject data)
        {
            var result = data.Value1 < data.Value2;
            Xunit.Assert.Equal(result, data.Result);
        }
    }

    public record DataObject
    {
        public int Value1 { get; internal set; } = default;

        public double Value2 { get; internal set; } = default;

        public bool Result { get; internal set; } = default;
    }
}
