using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using WebSiteCinema.DataStorage;

namespace WebSiteCinema.Services
{
    public static class AuthenticationsExtensions
    {
        public static void SetUserSessionData(this ISession session, string key, UserData value)
        {
            var str = JsonSerializer.Serialize(value);
            session.SetString(key, JsonSerializer.Serialize<UserData>(value));
        }
 
        public static UserData GetUserSessionData(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(UserData) : JsonSerializer.Deserialize<UserData>(value);
        }
        public static void SetUserData(this IResponseCookies cookieCollection, string key, UserData value)
        {
            var str = JsonSerializer.Serialize<UserData>(value);
            cookieCollection.Append(
                key,
                JsonSerializer.Serialize<UserData>(value),
                new CookieOptions()
                {
                    HttpOnly = true,
                    MaxAge = TimeSpan.FromDays(30),
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    IsEssential = true,
                });
        }
 
        public static UserData GetUserData(this IRequestCookieCollection cookieCollection, string key)
        {
            string resStr;
            cookieCollection.TryGetValue(key,out resStr);
            return resStr == null ? default(UserData) : JsonSerializer.Deserialize<UserData>(resStr);
        }
    }
}