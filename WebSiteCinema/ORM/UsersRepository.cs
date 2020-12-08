using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace ORM
{
    public class UsersRepository:DataConnection,IUsersRepository
    {
        public UsersRepository(LinqToDbConnectionOptions<UsersRepository> options)
            : base(options)
        {
            
        }

        private ITable<Users> Users => GetTable<Users>();
        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await Users.Select(x=>x).ToListAsync();
        }
        
        public async Task<Users> GetByLoginAsync(string login)
        {
            return await Users.FirstOrDefaultAsync(x => x.login == login);
        }

        public async  Task InsertAsync(Users user)
        {
            await Users.InsertAsync(() => new Users
            {
                login = user.login,
                email = user.email,
                password = user.password,
                phone = user.phone,
                role = user.role,
                status = user.status,
                avatar = user.avatar,
            });
        }

        public async Task DeleteAsync(Users user)
        {
            await Users.Where(x => x.Equals(user)).DeleteAsync();
        }

        public async Task DeleteAsync(string login )
        {
            await Users.Where(x => x.login==login).DeleteAsync();
        }
        

        /*public async Task UpdateAsync(int id,string login=null,string email=null,string password=null)
        {
            var usrs = Users.Where(u => u.id == id);
            if (login != null)
            {
                await usrs.Set(u => u.login, login).UpdateAsync();
            }
            if (email != null)
            {
                await usrs.Set(u => u.email, email).UpdateAsync();
            }
            if (password != null)
            {
                await usrs.Set(u => u.password, password).UpdateAsync();;
            }
            
        }*/
    }
}