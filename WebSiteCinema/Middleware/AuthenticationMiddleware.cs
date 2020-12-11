using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ORM;
using WebSiteCinema.Services;

namespace WebSiteCinema.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
 
        public async Task InvokeAsync(HttpContext context,IAuthentication authentication)
        {
            await authentication.AuthenticateAsync();
            await _next.Invoke(context);
        }
    }
}