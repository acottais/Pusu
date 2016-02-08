using System;
using Microsoft.AspNet.Builder;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Pusu.MiddleWare
{
    public class PusuDispatcher
    {
        private RequestDelegate _next;
        private string _greeting;
        private IServiceProvider _services;

        public PusuDispatcher(RequestDelegate next, string greeting, IServiceProvider services)
        {
            this._next = next;
            this._greeting = greeting;
            this._services = services;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync(_greeting + ", dispatching middleware!\r\n");
            await httpContext.Response.WriteAsync("This request is a " + httpContext.Request.Method + "\r\n");
            await httpContext.Response.WriteAsync("This request is a " + httpContext.Request.Path + "\r\n");
        }
    }
}
