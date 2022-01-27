using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bitrix24RestApiClientNUnitTests
{
    public static class JsonFileDataSource
    {
        public static IEnumerable GetData(string jsonFilePath, string testName = null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), jsonFilePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            var fileData = File.ReadAllText(path);

            if (string.IsNullOrEmpty(testName))
            //Весь файл является источником данных
            {
                return GetDataInternal(fileData, testName);
            }

            // Используем специфический раздел в качестве данных
            var allData = JObject.Parse(fileData);
            var data = allData[testName].ToString();
            return GetDataInternal(data, testName);
        }

        private static IEnumerable<TestCaseData> GetDataInternal(string jsonData, string testName)
        {
            var data = JsonConvert.DeserializeObject<object>(jsonData);
            return new List<TestCaseData>
            {
                new TestCaseData(data)
            {
                TestName = testName
            }
            };
        }
    }
}
