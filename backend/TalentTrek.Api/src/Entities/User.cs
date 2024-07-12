namespace TalentTrek.Api.Entities {
    public class User : BaseEntity
    {
        public string Uid {get; set;} = string.Empty;
        public required string Password {get; set;}
        public required string Email {get; set;}
        public required string ContactNo {get; set;}
        public required string UserType {get; set;}
    }
}