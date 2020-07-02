namespace WebServices_And_IntegrationTests.Model
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class HouseholdWishlist
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("isbn", NullValueHandling = NullValueHandling.Ignore)]
        public long? Isbn { get; set; }

        public static List<HouseholdWishlist> FromJson(string json) => JsonConvert.DeserializeObject<List<HouseholdWishlist>>(json, WebServices_And_IntegrationTests.Model.Converter.Settings);
    }

}
