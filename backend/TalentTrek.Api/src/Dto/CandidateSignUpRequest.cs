using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TalentTrek.Api.Dto 
{
    public class CandidateRegistrationRequest
    {
        [JsonPropertyName("id")]
        public string? Id {get; set;}

        [JsonPropertyName("firstName")]
        [Required]
        public required string FirstName {get; set;}

        [JsonPropertyName("lastName")]
        [Required]
        public required string LastName {get; set;}

        [JsonPropertyName("email")]
        [Required]
        public string? Email {get; set;}

        [JsonPropertyName("password")]
        [Required]
        [Range(8,30)]
        public string? Password {get; set;}

        [JsonPropertyName("confirmPassword")]
        [Required]
        public string? ConfirmPassword {get; set;}

        [JsonPropertyName("contactNo")]
        public string? ContactNo {get; set;}
    }
}