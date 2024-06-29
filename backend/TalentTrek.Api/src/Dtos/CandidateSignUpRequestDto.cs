using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TalentTrek.Api.Dtos 
{
    public class CandidateSignUpRequestDto
    {
        [JsonPropertyName("firstName")]
        [Required]
        public required string FirstName {get; set;}

        [JsonPropertyName("lastName")]
        [Required]
        public required string LastName {get; set;}

        [JsonPropertyName("email")]
        [Required]
        public required string Email {get; set;}

        [JsonPropertyName("password")]
        [Required]
        [Range(8,30)]
        public required string Password {get; set;}

        [JsonPropertyName("confirmPassword")]
        [Required]
        public required string ConfirmPassword {get; set;}

        [JsonPropertyName("contactNo")]
        public required string ContactNo {get; set;}
    }
}