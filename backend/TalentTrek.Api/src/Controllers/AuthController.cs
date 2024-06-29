using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthController(ILogger<AuthController> logger, IAuthService authService, IMapper mapper)
        {
            _logger = logger;
            _authService = authService;
            _mapper = mapper;
        }

        // api/auth/register/applicant
        // api/auth/register/employer
        [HttpPost("register/applicant")]
        public async Task<IActionResult> RegisterCandidate(string userType, [FromBody] CandidateSignUpRequest Candidate)
        {
            var result = await _authService.CreateCandidate(
                _mapper.Map<CandidateSignUpModel>(Candidate)
            );
            
            return Ok(result);
        }
    }
}
