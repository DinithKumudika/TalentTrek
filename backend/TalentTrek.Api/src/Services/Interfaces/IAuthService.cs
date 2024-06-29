using TalentTrek.Api.Models.Types;

namespace TalentTrek.Api.Services.Interfaces{
    public interface IAuthService
    {
        Task<string> CreateUser(UserType userType, object user);
    }
}