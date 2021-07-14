using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace ParcelManager.API.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorHandler(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        /// <summary>
        /// Invoke the middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            IEnumerable<string> exceptionMessages;
            var innerException = "";

            if (exception is FluentValidation.ValidationException validationException)
            {
                status = HttpStatusCode.BadRequest;
                exceptionMessages = validationException.Errors.Select(e => e.ErrorMessage);
            }
            else if (exception is ApplicationException applicationException)
            {
                status = HttpStatusCode.BadRequest;
                exceptionMessages = Enumerable.Repeat(applicationException.Message, 1);
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                exceptionMessages = Enumerable.Repeat(exception.Message, 1);
                if (exception.InnerException is not null)
                {
                    innerException = exception.InnerException.Message;
                }
            }

            var result = JsonSerializer.Serialize(new Response<ErrorDto>
            {
                Status = ResponseStatuses.Failure,
                Message = status.ToString(),
                Data = new ErrorDto
                {
                    ExceptionMessages = exceptionMessages,
                    InnerExceptionMessage = innerException
                }
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
