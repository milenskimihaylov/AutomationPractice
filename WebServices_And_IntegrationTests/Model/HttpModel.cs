using Newtonsoft.Json;
using System.Collections.Generic;
using WebServices_And_IntegrationTests.Model;

namespace WebServices_And_IntegrationTests.HttpModel
{
    public static class JsonExtensions
    {
        public static string ToJson(this List<Book> self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

        public static string ToJson(this Household self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

        public static string ToJson(this List<Household> self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

        public static string ToJson(this List<User> self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, WebServices_And_IntegrationTests.Model.Converter.Settings);

    }
}
