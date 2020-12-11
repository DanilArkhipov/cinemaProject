using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ORM;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UnitOfWork _unitOfWork;

        public IndexModel(ILogger<IndexModel> logger,UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        async public void OnGet()
        {
            /*await  _unitOfWork.MovieRepository.InsertAsync(new Movie
            (
                0,
                "Ещё по одной",
                new TimeSpan(0,2,15,0),
                "Заходят как-то в бар профессор истории, психолог, экономист и физрук. И решают проверить научную теорию: c самого рождения человек страдает от нехватки алкоголя в крови. Чтобы стать по-настоящему счастливым, нужно быть немного нетрезвым. Бокал вина утром, пинта пива в обед, стакан виски вечером. Казалось бы, что может пойти не так?", 
                        new DateTime(2020,11,18), 
                1,
                "/images/films/film4",
                "Ноунеймы какие-то чел с часами из криминального чтива ",
                DateTime.Now
                
                
            ));*/
        }
    }
}