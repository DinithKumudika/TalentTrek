using TalentTrek.Api.Data;
using TalentTrek.Api.Repositories.Interfaces;

namespace TalentTrek.Api.Repositories;
class AuthRepository : IAuthRepository
{
    private readonly DataContext _context;
    private readonly ILogger<AuthRepository> _looger;
    public AuthRepository(DataContext context, ILogger<AuthRepository> logger)
    {
        _context = context;
        _looger = logger;
    }
}