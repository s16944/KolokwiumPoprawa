using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KolokwiumPoprawa.Services;
using Microsoft.AspNetCore.Http;

namespace KolokwiumPoprawa.Middlewares
{
    public class ErrorMapMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMapMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (_next != null) await _next(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                var error = new Error {ErrorCode = 404, ErrorDescription = e.Message};
                await WriteToStream(context.Response.Body, error);
            }
            catch (ConflictException e)
            {
                context.Response.StatusCode = 409;
                var error = new Error {ErrorCode = 409, ErrorDescription = e.Message};
                await WriteToStream(context.Response.Body, error);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                var error = new Error {ErrorCode = 500, ErrorDescription = "Unknown server error"};
                await WriteToStream(context.Response.Body, error);
            }
        }

        private async Task WriteToStream(Stream stream, Error error)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                await writer.WriteAsync(JsonSerializer.Serialize(error));
                await writer.FlushAsync();
            }
        }
        
        private class Error
        {
            public int ErrorCode { get; set; }
            public string ErrorDescription { get; set; }
        }
    }
}