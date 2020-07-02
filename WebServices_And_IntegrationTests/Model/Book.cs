
namespace WebServices_And_IntegrationTests.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Book
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("publicationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PublicationDate { get; set; }

        [JsonProperty("isbn", NullValueHandling = NullValueHandling.Ignore)]
        public long? Isbn { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        public static List<Book> FromJson(string json) => JsonConvert.DeserializeObject<List<Book>>(json, WebServices_And_IntegrationTests.Model.Converter.Settings);
    }
}
