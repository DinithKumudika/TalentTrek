using TalentTrek.Api.Data;
using TalentTrek.Api.Models.Types;
using TalentTrek.Api.Services.Interfaces;

namespace TalentTrek.Api.Services{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ILogger<AuthService> _logger;

        public AuthService(DataContext context, ILogger<AuthService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> CreateUser(UserType userType, object user)
        {
            // TODO: implement the rest of the registration logic
            switch (userType)
            {
                case UserType.Applicant:
                case UserType.Employer:
                    return "user is an employer";
                default:
                    throw new Exception("Invalid user type");
            }
        }
    }
}