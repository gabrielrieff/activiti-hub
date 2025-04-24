using ActivityHub.Application.UseCase.Auth;
using ActivityHub.Communication.Request.Authenticated;
using Microsoft.AspNetCore.Mvc;

namespace ActivityHub.Api.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        [HttpPost("login-github")]
        [ProducesResponseType(typeof(RequestAuthenticatedWithGithub), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AuthenticatedWithGithub(
            [FromBody] RequestAuthenticatedWithGithub request,
            [FromServices] IAuthenticatedWithGithubUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
