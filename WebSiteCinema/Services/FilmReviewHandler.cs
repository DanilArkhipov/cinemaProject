using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ORM;
using WebSiteCinema.Models;
using WebSocketManager;

namespace WebSiteCinema.Services
{
    public class FilmReviewHandler : WebSocketHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FilmReviewHandler(WebSocketConnectionManager webSocketConnectionManager,IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider) : base(webSocketConnectionManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceProvider = serviceProvider;
        }
        public async Task SendMessage(string message,string user_login,string movie_id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
                var review = new MovieReview(user_login, int.Parse(movie_id), message, DateTime.Now);
                await unitOfWork.MovieReviewRepository.InsertAsync(review);
                await InvokeClientMethodToAllAsync("pingMessage",  message,user_login,review.date);
            }
        }
    }
}