using Infraestructure.Crosscutting.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting.Logging
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment _env;
        private readonly ILogger _logger;
        private readonly IStringLocalizer<ValidationResource> _localizer;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            IHostEnvironment env,
            IStringLocalizer<ValidationResource> localizer)
        {
            this.next = next;
            _env = env;
            _logger = Log.Logger;
            _localizer = localizer;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var completeMessage = GetCompleteExceptionMessage(ex);
                _logger.Fatal(ex, "Error controlado por la aplicación: {@mensaje}", completeMessage);

                if (ex is DbUpdateException)
                    await ProcessSqlServerErrorResponse(ex, context); 
                else
                    await ProcessDefaultResponse(ex, context);
            }
        }

        private async Task ProcessDefaultResponse(Exception ex, HttpContext context)
        {
            var completeMessage = GetCompleteExceptionMessage(ex);
            var message = _env.IsDevelopment() ? completeMessage : ex.Message;

            await WriteResponse(message, context);
        }

        private async Task ProcessSqlServerErrorResponse(Exception ex, HttpContext context)
        {
            var innerException = ex.InnerException as SqlException;
            string mensajeError = string.Empty;

            var completeMessage = GetCompleteExceptionMessage(ex);
            var message = _env.IsDevelopment() ? completeMessage : ex.Message;

            switch (innerException.Number)
            {
                case ErrorNumbers.DuplicatedKeyRowError:
                    mensajeError = _localizer[ResourcesNames.Validation.DuplicatedKeyRowError];
                    break;

                case ErrorNumbers.ConstraintCheckViolation:
                    mensajeError = _localizer[ResourcesNames.Validation.ConstraintCheckViolation];
                    break;

                case ErrorNumbers.UniqueConstraintError:
                    mensajeError = _localizer[ResourcesNames.Validation.UniqueConstraintError];
                    break;

                default:
                    mensajeError = message;
                    break;
            }

            await WriteResponse(mensajeError, context);
        }

        private async Task WriteResponse(string message, HttpContext context)
        {
            context.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(context.Response.Body))
            {
                var jsonSerilizer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                jsonSerilizer.Serialize(writer, new JsonResult<object>(false, message));

                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        private string GetCompleteExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;
            var errorMessage = $"{ex.Message}\n{GetCompleteExceptionMessage(ex.InnerException)}";

            return errorMessage;
        }
    }
}
