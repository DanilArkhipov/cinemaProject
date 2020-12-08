using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebSiteCinema.Services;

namespace WebSiteCinema.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private IAuthorization _authorization;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
 
        public async Task InvokeAsync(HttpContext context,IAuthorization authorization)
        {
            _authorization = authorization;
            await _next.Invoke(context);
        }
    }
}