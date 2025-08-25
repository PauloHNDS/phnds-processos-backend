
using Microsoft.AspNetCore.Mvc;
using phnds_processos.api.Auth;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase    
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request.Email, request.Senha );
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var result = await _authService.RefreshTokenAsync(refreshToken);
            return Ok(result);
        }
    }
}
