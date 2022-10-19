using Newtonsoft.Json;
using JsonConstructorAttribute = System.Text.Json.Serialization.JsonConstructorAttribute;

namespace Sovtech.Data.Models.Chuck
{

    public class ChuckQuerySearchResponse
    {
        [JsonConstructor]
        public ChuckQuerySearchResponse([JsonProperty("total")] int total, [JsonProperty("result")] List<CategoryResult> result)
        {
            this.Total = total;
            this.Result = result;
        }

        [JsonProperty("total")]
        public int Total { get; }

        [JsonProperty("result")]
        public IReadOnlyList<CategoryResult> Result { get; }
    }
}