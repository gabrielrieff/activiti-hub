using ActivityHub.Application.UseCase.Users.GetProfile;
using ActivityHub.Application.UseCase.Users.UpdateProfile;
using ActivityHub.Communication.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProfile([FromServices] IGetProfileUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProfile(
            [FromServices] IUpdateProfileUser useCase,
            [FromBody] RequestUpdateProfileJson request)
        {
            await useCase.Execute(request);
            return NoContent();
        } 
    }
}
