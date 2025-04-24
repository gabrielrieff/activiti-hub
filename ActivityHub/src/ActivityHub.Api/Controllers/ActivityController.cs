using ActivityHub.Application.UseCase.Activities.Delete;
using ActivityHub.Application.UseCase.Activities.GetById;
using ActivityHub.Application.UseCase.Activities.ListMonth;
using ActivityHub.Application.UseCase.Activities.Register;
using ActivityHub.Application.UseCase.Activities.UpdateStatus;
using ActivityHub.Application.UseCase.Activities.UpdateText;
using ActivityHub.Communication.Request.Activities;
using ActivityHub.Communication.Response;
using ActivityHub.Communication.Response.Activities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityHub.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ActivityController : ControllerBase
{

    [HttpPost("Register")]
    [ProducesResponseType(typeof(ResponseRegisterActivityJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterActivityUseCase useCase,
        [FromBody] RequestRegisterActityJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteActivityUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetActivitiesById(
        [FromServices] IGetActivityByIdUseCase useCase,
        [FromRoute] int id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseActivitiesListJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListMonth(
        [FromServices] IActivitiesListMonthUseCase useCase,
        [FromQuery] int month,
        [FromQuery] int year)
    {
        var response = await useCase.Execute(month, year);
        return Ok(response);
    }

    //[HttpGet("list-activities?page={page}&size={size}&month={month}&year={year}")]
    //[ProducesResponseType(typeof(ResponseActivitiesInPageSize), StatusCodes.Status200OK)]
    //public async Task<IActionResult> ListActivitiesPage(
    //    [FromServices] IListActivityInPage useCase,
    //    int month,
    //    int year,
    //    int page,
    //    int size)
    //{

    //}

    [HttpPut("{id}/update-status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateStatus(
        [FromServices] IActivityUpdateStatusUseCase useCase,
        [FromBody] RequestUpdateStatusActivityJson request,
        int id)
    {
        await useCase.Execute(id, request);
        return NoContent();
    }
    
    [HttpPut("{id}/update-text")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateText(
        [FromServices] IActivityUpdateTextUseCase useCase,
        [FromBody] RequestUpdateText request,
        int id)
    {
        await useCase.Execute(id, request);
        return NoContent();
    }

}
