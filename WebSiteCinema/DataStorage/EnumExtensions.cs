using WebSiteCinema.Services;

namespace WebSiteCinema.DataStorage
{
    public static class EnumExtesions
    {
        public static string GetString(this MovieStatus movieStatus)
        {
            return movieStatus switch
            {
                MovieStatus.Active => "Активно",
                MovieStatus.Blocked => "Заблокировано"
            };
        }
        public static string GetString(this UserStatus userStatus)
        {
            return userStatus switch
            {
                UserStatus.Active=> "Активен",
                UserStatus.Banned=>"Заблокирован"
            };
        }
        public static string GetString(this UserRole userRole)
        {
            return userRole switch
            {
                UserRole.Admin=>"Администратор",
                UserRole.Default=>"Пользователь",
                UserRole.NonAuthenticated=>"Не авторизован"
            };
        }
    }
}