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
    public class UsersRepository:UnitOfWork,IUsersRepository
    {
        public UsersRepository(LinqToDbConnectionOptions<UnitOfWork> options)
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
        

        public async Task UpdateAsync(Users newUser,Users oldUser)
        {
            await Users.Where(u=>u.login==oldUser.login).UpdateAsync(users => new Users()
            {
                email = newUser.email ?? oldUser.email,
                phone = newUser.phone ?? oldUser.phone,
                password = newUser.password ?? oldUser.password,
                role = newUser.role != oldUser.role ? newUser.role : oldUser.role,
                status = newUser.status != oldUser.status ? newUser.status : oldUser.status,
            });
        }
    }
}