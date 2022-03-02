using System;
using System.IO;
using Xunit.Sdk;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Test.Utilities
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly string _propertyName;

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public JsonFileDataAttribute(string filePath)
            : this(filePath, null) { 
        }

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        /// <param name="propertyName">The name of the property on the JSON file that contains the data for the test</param>
        public JsonFileDataAttribute(string filePath, string propertyName)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            string path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
                throw new ArgumentException($"Could not find file at path: {path}");

            string fileData = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(_propertyName))
                return GetData(JArray.Parse(fileData), testMethod);

            JObject allData = JObject.Parse(fileData);
            JToken data = allData[_propertyName];

            return GetData(data, testMethod); 
        }

        private IEnumerable<object[]> GetData(JToken data, MethodInfo testMethod)
        {
            JArray testDataList = data as JArray;

            foreach (JArray argsFromJson in testDataList)
                yield return ParseArgs(argsFromJson, testMethod);
        }


        private object[] ParseArgs(JArray argsFromJson, MethodInfo testMethod)
        {
            ParameterInfo[] methodParams = testMethod.GetParameters();

            if (methodParams.Length != argsFromJson.Count)
                throw new ArgumentException(
                    $"Test data in the file '{_filePath}' should contain the same number of objects as the number of the test method arguments. " +
                    $"Expected: {methodParams.Length}. " +
                    $"Actual: {argsFromJson.Count}");

            object[] objData = new object[methodParams.Length];
            for (int i = 0; i < methodParams.Length; i++)
            {
                objData[i] = ParseArgs(argsFromJson[i], methodParams[i]);
            }
            return objData;
        }

        private object ParseArgs(JToken argFromJson, ParameterInfo paramInfo)
        {            
            Type methodParamType = paramInfo.ParameterType;
            return argFromJson.ToObject(methodParamType);
        }
    }

}
