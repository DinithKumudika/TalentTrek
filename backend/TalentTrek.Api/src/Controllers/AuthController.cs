using Microsoft.AspNetCore.Mvc;
using TalentTrek.Api.Dto;
using TalentTrek.Api.Entities;
using TalentTrek.Api.Models;
using TalentTrek.Api.Models.Types;
using TalentTrek.Api.Services.Interfaces;

namespace TalentTrek.Api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        // api/auth/register/applicant
        // api/auth/register/employer
        [HttpPost("register/{userType}")]
        public async Task<IActionResult> AddUser(string userType, [FromBody] CandidateRegistrationRequest request)
        {
            var result = await _authService.CreateUser(
                (UserType)Enum.Parse(typeof(UserType), userType), 
                request
            );
            
            return Ok(result);
        }
    }
}
