using Microsoft.AspNetCore.Html;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace WebSiteCinema.HtmlContentMakers
{
    public class AdminFilmsPage
    {
        public static IHtmlContent CreateFilmRow(Movie movie,string viewLink,string editLink,string deleteTag)
        {
            return new HtmlString(string.Format(@"<tr>
            <td>{0}</td>
            <td>{1}</td>
            <td>{2}</td>
            <td>{3}</td>
            <td>{4}</td>
            <td>
                <a href='{5}'><i class='fa fa-eye'></i></a>
                <a href='{6}'><i class='fa fa-pencil'></i></a>
                <a href='{7}'><i class='fa fa-trash'></i></a>
                </td>
                </tr>",movie.id,movie.name,movie.category,((MovieStatus)movie.status).GetString(),movie.age_rating,
                viewLink,editLink,deleteTag));
        }
    }
}