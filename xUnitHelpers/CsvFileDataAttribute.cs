using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace xUnitHelpers
{
    public class CsvFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;

        private readonly Type _dataType;

        public CsvFileDataAttribute(string filePath, Type dataType)
        {
            _filePath = filePath;
            _dataType = dataType;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Get the absolute path to the csv file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            var properties = _dataType.GetProperties();

            using (var csvFile = new StreamReader(_filePath))
            {
                var headerDictionary = GetHeaders(csvFile);

                return GetData(csvFile, properties, headerDictionary);
            }
        }

        private IReadOnlyCollection<object[]> GetData(StreamReader csvFile, IReadOnlyCollection<PropertyInfo> properties, IReadOnlyDictionary<string, int> headerDictionary)
        {
            string? line;
            var objectList = new List<object[]>();

            while ((line = csvFile.ReadLine()) != null)
            {
                var row = line.Split(',');
                var instance = Activator.CreateInstance(_dataType);

                foreach (var property in properties)
                {
                    var propertyName = property.Name.ToLower();

                    var valueAsString = row[headerDictionary[propertyName]].Trim();
                    var value = Convert.ChangeType(valueAsString, property.PropertyType);
                    property.SetValue(instance, value);
                }

                objectList.Add(new[] { instance ?? throw new InvalidOperationException() });
            }

            return objectList;
        }

        private static Dictionary<string, int> GetHeaders(StreamReader csvFile)
        {
            var line = csvFile.ReadLine();
            var row = line!.Split(',');

            var dict = new Dictionary<string, int>();

            for (var i = 0; i < row.Length; i++)
            {
                dict.Add(row[i].Trim().ToLower(), i);
            }

            return dict;
        }
    }
}
