using BarberBoss.Communication.Response;
using BarberBoss.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters
{
    public class ExeceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BarberBossException)
            {
                HandleProjectExecption(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectExecption(ExceptionContext context)
        {
            var barberBossException = context.Exception as BarberBossException;
            var errorResponse = new ResponseError(barberBossException!.GetErros());
            context.HttpContext.Response.StatusCode = barberBossException.StatusCode;
            context.Result = new ObjectResult(errorResponse);

        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ResponseError("Unknown Error");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);

        }
    }
}
