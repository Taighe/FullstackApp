using ASP_MVCNetCoreExample.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate m_next;
        private ILogger<ExceptionMiddleware> m_logger;
        private IHostEnvironment m_env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            m_next = next;
            m_logger = logger;
            m_env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await m_next(context);
            }
            catch (Exception ex)
            {
                m_logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = m_env.IsDevelopment() ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) :
                    new ApiException(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                
                await context.Response.WriteAsync(json);
            }
        }
    }
}
