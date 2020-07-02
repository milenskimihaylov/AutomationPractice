namespace WebServices_And_IntegrationTests.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("wishlistId", NullValueHandling = NullValueHandling.Ignore)]
        public long? WishlistId { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("householdId", NullValueHandling = NullValueHandling.Ignore)]
        public long? HouseholdId { get; set; }

        public static List<User> FromJson(string json) => JsonConvert.DeserializeObject<List<User>>(json, WebServices_And_IntegrationTests.Model.Converter.Settings);
    }

}
