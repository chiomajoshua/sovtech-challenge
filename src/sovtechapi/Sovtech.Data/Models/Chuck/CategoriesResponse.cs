using Newtonsoft.Json;

namespace Sovtech.Data.Models.Chuck
{
    [JsonArray]
    public class CategoriesResponse
    {
        public CategoriesResponse(string[] categories)
        {
            Categories = categories;
        }
        public IReadOnlyList<string> Categories { get; set; }
    }
}