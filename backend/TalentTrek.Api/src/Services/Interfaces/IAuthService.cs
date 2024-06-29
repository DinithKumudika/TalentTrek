using TalentTrek.Api.Models;
using TalentTrek.Api.Models.Types;

namespace TalentTrek.Api.Services.Interfaces{
    public interface IAuthService
    {
        Task<string> CreateCandidate(CandidateSignUpModel candidate);
    }
}