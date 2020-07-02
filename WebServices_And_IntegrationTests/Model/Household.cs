namespace WebServices_And_IntegrationTests.Model
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;

    public class Household
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        public static List<Household> FromJson(string json) => JsonConvert.DeserializeObject<List<Household>>(json, WebServices_And_IntegrationTests.Model.Converter.Settings);

    }

}
