using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using WebSiteCinema.Models;

namespace WebSiteCinema.HtmlContentMakers
{
    public class IndexPage
    {
        public static IHtmlContent CreateFilmCard(Movie movie,string url)
        {
            var htmlString = new HtmlString
            (
                string.Format(
                    @"<div class='col-sm-3 col-6'>
            <div class='film-item'>
                <div class='film-image'>
                    <img alt='Film Name' src='{0}'>
                </div>
                <div class='film-meta'>
                    <div class='film-name'>
                        {1}
                    </div>
                    <div class='film-category'>
                        {2}
                    </div>
                </div>
                <div class='film-meta-full'>
                    <div class='film-name'>
                        {1}
                    </div>
                    <div class='film-category'>
                        {2}
                    </div>
                    <div class='film-description'>
                        {3}
                    </div>
                    <div class='film-button'>
                        <a class='btn' href='{4}'>Подробнее</a>
                    </div>
                </div>
            </div>
        </div>", movie.poster, movie.name, movie.category, movie.description,url));
            return htmlString;
        }
    }
}