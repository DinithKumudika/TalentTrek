namespace TalentTrek.Api.Entities 
{
    public class Candidate
    {
        public int Id {get; set;}
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public DateTime CreatedOn {get; set;}
        public required int UserId {get; set;}
        public User? User {get; set;}
    }
}