namespace TalentTrek.Api.Entities {
    public class Employer : BaseEntity
    {
        public required string CompanyName {get; set;}
        public required string Position {get; set;}
        public required int UserId {get; set;}
        public User? User {get; set;}
    }
}