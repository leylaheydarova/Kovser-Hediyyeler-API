using KovserHedieyyeler.Application.Features.Commands.WebUsers.GoogleLogin;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.Login;
//using KovserHedieyyeler.Application.Features.Commands.WebUsers.PasswordReset;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.RefreshTokenLogin;
//using KovserHedieyyeler.Application.Features.Commands.WebUsers.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> LoginAsync(UserLoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }//done

        [HttpPost("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        //[HttpPost("password-reset")]
        //public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        //{
        //    PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
        //    return Ok(response);
        //}

        //[HttpPost("verify-reset-token")]
        //public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        //{
        //    VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
        //    return Ok(response);
        //}
    }
}
