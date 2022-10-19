using Newtonsoft.Json;

namespace Sovtech.Data.Models.Swapi
{
    public class PeopleResponse
    {
        [JsonConstructor]
        public PeopleResponse(
            [JsonProperty("count")] int count,
            [JsonProperty("next")] string next,
            [JsonProperty("previous")] object previous,
            [JsonProperty("results")] List<PeopleResult> results
        )
        {
            this.Count = count;
            this.Next = next;
            this.Previous = previous;
            this.Results = results;
        }

        [JsonProperty("count")]
        public int Count { get; }

        [JsonProperty("next")]
        public string Next { get; }

        [JsonProperty("previous")]
        public object Previous { get; }

        [JsonProperty("results")]
        public IReadOnlyList<PeopleResult> Results { get; }
    }
}