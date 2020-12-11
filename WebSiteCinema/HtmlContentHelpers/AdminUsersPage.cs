using Microsoft.AspNetCore.Html;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.HtmlContentMakers
{
    public class AdminUsersPage
    {
        public static IHtmlContent CreateUserRow(Users user,string editLink)
        {
            return new HtmlString(string.Format(@"<tr>
            <td>{0}</td>
            <td>{1}</td>
            <td>{2}</td>
            <td>{3}</td>
            <td>{4}</td>
            <td>
                <a href='{5}'><i class='fa fa-pencil'></i></a>
                </td>
                </tr>",user.login,user.email,user.phone,((UserStatus)user.status).GetString(),((UserRole)user.role).GetString(),
                editLink));
        }
    }
}