using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NewsAggregator.MiddlewareComponents
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "qwe12312sdfsd")
            {
                context.Response.StatusCode = 401;//Unauthorized
                await context.Response.WriteAsync("Invalid token");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
