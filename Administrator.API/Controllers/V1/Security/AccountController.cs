using Administrator.API.Errors;
using Administrator.Application.Contracts.Identity;
using Administrator.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Administrator.API.Controllers.Security.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request">AuthRequest object</param>
        /// <returns>Return login AuthResponse</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request">RegistrationRequest object</param>
        /// <returns>Return new register object</returns>
        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegistrationResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        /// <summary>
        /// Refresh token
        /// </summary>
        /// <param name="request">TokenRequest object</param>
        /// <returns>AuthResponse object</returns>
        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] TokenRequest request)
        {
            return Ok(await _authService.RefreshToken(request));
        }
    }
}
