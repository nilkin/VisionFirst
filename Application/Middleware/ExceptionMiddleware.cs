﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.Middleware
{
    public class ExceptionMiddleware
    {
        public class Exception
        {
            public Exception(short statusCode, string message, string details)
            {
                StatusCode = statusCode;
                Message = message;
                Details = details;
            }
            public short StatusCode { get; set; }
            public string Message { get; set; }
            public string Details { get; set; }
        }

        private readonly RequestDelegate _next;
        private readonly Logger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, Logger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (short)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()
                    ? new Exception(((short)context.Response.StatusCode), ex.Message, ex.StackTrace.ToString())
                    : new Exception(((short)context.Response.StatusCode), ex.Message, "Internal Server Error");
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
