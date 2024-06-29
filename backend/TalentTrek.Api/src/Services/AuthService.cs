using System.Security.Cryptography;
using TalentTrek.Api.Data;
using TalentTrek.Api.Models;
using TalentTrek.Api.Services.Interfaces;
using TalentTrek.Api.Utils;

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
            var hashedPasword = Crypto.HashPassword(candidate.Password, out var salt);
            Console.WriteLine($"Hashed Password: {hashedPasword}");
            Console.WriteLine($"Password Salt: {Convert.ToHexString(salt)}");
            var verificationRes = Crypto.VerifyPassword(candidate.Password, hashedPasword, salt) ? "is successfull": "has failed";
            Console.WriteLine($"Password verfication {verificationRes}");
            
            // TODO: implement the rest of the registration logic
            return "candidate added";
        }
    }
}