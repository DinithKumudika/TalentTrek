using TalentTrek.Api.Data;
using TalentTrek.Api.Repositories.Interfaces;

namespace TalentTrek.Api.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DataContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
