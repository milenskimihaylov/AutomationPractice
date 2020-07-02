namespace WebServices_And_IntegrationTests.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserWishlist
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("books", NullValueHandling = NullValueHandling.Ignore)]
        public List<Book> Books { get; set; }

        public static UserWishlist FromJson(string json) => JsonConvert.DeserializeObject<UserWishlist>(json, WebServices_And_IntegrationTests.Model.Converter.Settings);
    }
}
