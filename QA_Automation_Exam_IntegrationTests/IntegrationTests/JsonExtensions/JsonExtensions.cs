using IntegrationTests.Models;
using Newtonsoft.Json;

namespace IntegrationTests.JsonExtensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
