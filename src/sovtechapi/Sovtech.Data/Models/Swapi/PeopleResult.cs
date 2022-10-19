using Newtonsoft.Json;

namespace Sovtech.Data.Models.Swapi
{
    public class PeopleResult
    {
        [JsonConstructor]
        public PeopleResult(
            [JsonProperty("name")] string name,
            [JsonProperty("height")] string height,
            [JsonProperty("mass")] string mass,
            [JsonProperty("hair_color")] string hairColor,
            [JsonProperty("skin_color")] string skinColor,
            [JsonProperty("eye_color")] string eyeColor,
            [JsonProperty("birth_year")] string birthYear,
            [JsonProperty("gender")] string gender,
            [JsonProperty("homeworld")] string homeworld,
            [JsonProperty("films")] List<string> films,
            [JsonProperty("species")] List<string> species,
            [JsonProperty("vehicles")] List<string> vehicles,
            [JsonProperty("starships")] List<string> starships,
            [JsonProperty("created")] DateTime created,
            [JsonProperty("edited")] DateTime edited,
            [JsonProperty("url")] string url
        )
        {
            this.Name = name;
            this.Height = height;
            this.Mass = mass;
            this.HairColor = hairColor;
            this.SkinColor = skinColor;
            this.EyeColor = eyeColor;
            this.BirthYear = birthYear;
            this.Gender = gender;
            this.Homeworld = homeworld;
            this.Films = films;
            this.Species = species;
            this.Vehicles = vehicles;
            this.Starships = starships;
            this.Created = created;
            this.Edited = edited;
            this.Url = url;
        }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("height")]
        public string Height { get; }

        [JsonProperty("mass")]
        public string Mass { get; }

        [JsonProperty("hair_color")]
        public string HairColor { get; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; }

        [JsonProperty("gender")]
        public string Gender { get; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; }

        [JsonProperty("films")]
        public IReadOnlyList<string> Films { get; }

        [JsonProperty("species")]
        public IReadOnlyList<string> Species { get; }

        [JsonProperty("vehicles")]
        public IReadOnlyList<string> Vehicles { get; }

        [JsonProperty("starships")]
        public IReadOnlyList<string> Starships { get; }

        [JsonProperty("created")]
        public DateTime Created { get; }

        [JsonProperty("edited")]
        public DateTime Edited { get; }

        [JsonProperty("url")]
        public string Url { get; }
    }
}