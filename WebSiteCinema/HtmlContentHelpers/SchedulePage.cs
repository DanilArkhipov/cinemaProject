using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Html;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Pages;

namespace WebSiteCinema.HtmlContentMakers
{
    public class SchedulePage
    {
        public static IHtmlContent CreateFilmCard(Movie movie)
        {
            return new HtmlString(string.Format(
                @"<div class='film-sessions'>
                <div class='film-data'>
                <div class='film-name'>{0}</div>
                <div class='film-meta'>{1}</div>
                <div class='film-description'>{2}</div>
                </div>
                <ul>
                    <li><a class='session' href='#'>22:00</a></li>
                </ul>
                </div>",movie.name,movie.category,movie.description));
        }

        
    }
}