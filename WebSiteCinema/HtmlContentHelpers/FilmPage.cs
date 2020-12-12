using Microsoft.AspNetCore.Html;
using WebSiteCinema.Models;

namespace WebSiteCinema.HtmlContentMakers
{
    public class FilmPage
    {
        public static IHtmlContent CreateFilmReview(MovieReview movieReview)
        {
            return new HtmlString
            (
                string.Format(
                    @"
            <div class='review'>
                <div class='review-header'>
                    <span class='review-user'>{0}</span>
                    <span class='review-date'>{1}</span>
                </div>
                <div class='review-text format-review'>{2}</div>
            </div>",movieReview.user_login,movieReview.date.ToString("yyyy-mm-dd" +" " +movieReview.date.Hour +":" + movieReview.date.Minute),
                    movieReview.review)
                );
        }
    }
}