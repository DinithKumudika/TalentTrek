namespace TalentTrek.Api.Entities {
    public class Employer 
    {
        public int Id {get; set;}
        public required string CompanyName {get; set;}
        public required string Position {get; set;}
        public DateTime CreatedOn {get; set;}
        public required int UserId {get; set;}
        public User? User {get; set;}
    }
}