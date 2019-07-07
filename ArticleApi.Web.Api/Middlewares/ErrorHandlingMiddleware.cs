using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ArticleApi.Application.Exceptions;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ArticleApi.Web.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            const HttpStatusCode code = HttpStatusCode.InternalServerError;

            var exception = ex as ExceptionBase;

            var responseCode = exception != null ? (int) exception.StatusCode : (int) code;

            var result = JsonConvert.SerializeObject(new ErrorResponse(responseCode, ex));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = responseCode;
            return context.Response.WriteAsync(result);
        }
    }
}
