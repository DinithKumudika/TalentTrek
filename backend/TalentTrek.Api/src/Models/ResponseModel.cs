using System.Text.Json.Serialization;

namespace TalentTrek.Api.Models 
{
    public class ResponseModel
    {
        [JsonPropertyName("statusCode")]
        public required int StatusCode {get; set;}
        [JsonPropertyName("data")]
        public object? Data {get; set;}
        [JsonPropertyName("description")]
        public string? Description {get; set;}
    }
}