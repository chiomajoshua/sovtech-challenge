using Newtonsoft.Json;

namespace Sovtech.Data.Models.Chuck
{
    public class CategoryResult
    {
        [JsonConstructor]
        public CategoryResult(
            [JsonProperty("categories")] List<string> categories,
            [JsonProperty("created_at")] string createdAt,
            [JsonProperty("icon_url")] string iconUrl,
            [JsonProperty("id")] string id,
            [JsonProperty("updated_at")] string updatedAt,
            [JsonProperty("url")] string url,
            [JsonProperty("value")] string value
        )
        {
            this.Categories = categories;
            this.CreatedAt = createdAt;
            this.IconUrl = iconUrl;
            this.Id = id;
            this.UpdatedAt = updatedAt;
            this.Url = url;
            this.Value = value;
        }

        [JsonProperty("categories")]
        public IReadOnlyList<string> Categories { get; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        [JsonProperty("url")]
        public string Url { get; }

        [JsonProperty("value")]
        public string Value { get; }
    }
}