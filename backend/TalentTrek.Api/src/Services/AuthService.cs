using TalentTrek.Api.Data;
using TalentTrek.Api.Models;
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

        public async Task<string> CreateCandidate(CandidateSignUpModel candidate)
        {
            // TODO: implement the rest of the registration logic
            return "candidate added";
        }
    }
}