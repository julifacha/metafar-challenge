using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Commands;
using Services.Interfaces;

namespace MetafarChallenge.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService) : base()
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginDto)
        {
            var token = await _authService.Authenticate(loginDto);
            return Ok(token);            
        }
    }
}
