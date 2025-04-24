using Microsoft.AspNetCore.Mvc;
using NotificationService.API.Application.UseCase.List;
using NotificationService.API.Application.UseCase.Register;
using NotificationService.API.Models.Request;

namespace NotificationService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromQuery] int userId, [FromServices] IListNotificationUseCase useCase)
    {
        var notifications = await useCase.Execute(userId);
        return Ok(notifications);
    }

    //[HttpPatch("{id}/mark-as-read")]
    //public async Task<IActionResult> MarkAsRead([FromQuery] string id, [FromServices] IMarkAsReadUseCase useCase)
    //{
    //    await useCase.Execute(id);
    //    return NoContent();
    //}

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RegisterNotificationRequest request,
        [FromServices] IRegisterNotificationUseCase useCase )
    {
        await useCase.Execute(request);
        return NoContent();
    }
}
