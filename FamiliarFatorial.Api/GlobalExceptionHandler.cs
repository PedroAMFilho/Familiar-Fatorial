using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FamiliarFatorial.Domain;
using FamiliarFatorial.Domain.DivisorContext.Commands.Outputs;

namespace FamiliarFatorial.Api
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger,
            IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var contextException = context.Exception;
            var baseException = contextException.GetBaseException();
            var response = context.HttpContext.Response;

            CommandResult commandResult = new CommandResult(
                false,
                $"Opss, houve um erro (1). { status }: { context.Exception.Message }. " +
                $"Tente novamente, ou, contacte o administrador do sistema",
                new { });

            if (contextException.GetType() == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                commandResult = new CommandResult(
                    false,
                    $"Opss, houve um erro (2). { status }: { context.Exception.Message }" +
                    $"Tente novamente, ou, contacte o administrador do sistema",
                    new { });
            }
            else if (contextException.GetType() == typeof(NullReferenceException))
            {
                status = HttpStatusCode.NotFound;
                commandResult = new CommandResult(
                    false,
                    $"Opss, houve um erro (3). { status }: { context.Exception.Message }" +
                    $"Tente novamente, ou, contacte o administrador do sistema",
                    new { });
            }

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(commandResult);
        }
    }
}
