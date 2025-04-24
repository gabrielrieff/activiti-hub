using ActivityHub.Communication.Response;
using ActivityHub.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActivityHub.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ActivityHubException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThworUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var financeFlowException = (ActivityHubException)context.Exception;
        var errorMessage = new ResponseErrorJson(financeFlowException.GetErrors());

        context.HttpContext.Response.StatusCode = financeFlowException.StatusCode;
        context.Result = new ObjectResult(errorMessage);

    }

    private void ThworUnkowError(ExceptionContext context)
    {
        var errorMessage = new ResponseErrorJson("Erro desconhecido");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorMessage);
    }
}
