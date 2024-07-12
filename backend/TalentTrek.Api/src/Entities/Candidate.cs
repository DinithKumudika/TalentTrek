namespace TalentTrek.Api.Entities 
{
    public class Candidate : BaseEntity
    {
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public required int UserId {get; set;}
        public User? User {get; set;}
    }
}