using Ascend_Forum.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ascend_Forum.Infrastructure
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EntityNotFoundException)
            {
                context.Result = new ViewResult
                {
                    ViewName = "~/Views/Error/BadRequest.cshtml",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
