using System.Text.Json.Serialization;

namespace TalentTrek.Api.Models
{
    class ReponseErrorModel
    {
        [JsonPropertyName("statusCode")]
        public required int StatusCode {get; set;}
        [JsonPropertyName("description")]
        public string? Description {get; set;}
        [JsonPropertyName("errors")]
        public required object Errors {get; set;}
    }
}
