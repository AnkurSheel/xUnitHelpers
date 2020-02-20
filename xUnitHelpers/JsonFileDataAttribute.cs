using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

namespace xUnitHelpers
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;

        private readonly string _propertyName;

        private readonly Type _dataType;

        private readonly Type _resultType;

        public JsonFileDataAttribute(string filePath, Type dataType, Type resultType)
        {
            _filePath = filePath;
            _dataType = dataType;
            _resultType = resultType;
        }

        public JsonFileDataAttribute(string filePath, string propertyName, Type dataType, Type resultType)
        {
            _filePath = filePath;
            _propertyName = propertyName;
            _dataType = dataType;
            _resultType = resultType;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var parameters = testMethod.GetParameters();
            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(_propertyName))
                //whole file is the data
            {
                return GetData(fileData);
            }

            // Only use the specified property as the data
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName].ToString();
            return GetData(data);
        }

        private IEnumerable<object[]> GetData(string jsonData)
        {
            var specific = typeof(TestObject<,>).MakeGenericType(_dataType, _resultType);
            var generic = typeof(List<>).MakeGenericType(specific);

            dynamic datalist = JsonConvert.DeserializeObject(jsonData, generic);
            var objectList = new List<object[]>();
            foreach (var data in datalist)
            {
                objectList.Add(new object[] {data.Data, data.Result});
            }

            return objectList;
        }
    }
}