using System.Text.Json;
using Microsoft.AspNetCore.Http;
using SeriallizatioData;

namespace WebSiteCinema.Authorization
{
    public static class UserSessionExtesions
    {
        public static void SetUserSessionData(this ISession session, string key, UserSession value)
        {
            session.SetString(key, JsonSerializer.Serialize<UserSession>(value));
        }
 
        public static UserSession GetUserSessionData(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(UserSession) : JsonSerializer.Deserialize<UserSession>(value);
        }
    }
}