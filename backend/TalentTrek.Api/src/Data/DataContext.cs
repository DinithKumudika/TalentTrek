using Microsoft.EntityFrameworkCore;
using TalentTrek.Api.Entities;

namespace TalentTrek.Api.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Candidate> Applicants {get; set;}
        public DbSet<Employer> Employers {get; set;}
    }
}