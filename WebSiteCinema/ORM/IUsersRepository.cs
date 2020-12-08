using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<Users>> GetAllAsync();
        public Task<Users> GetByLoginAsync(string login);
        public Task InsertAsync(Users user);
        public Task DeleteAsync(Users user);
        public Task DeleteAsync(string login);
        /*public Task UpdateAsync(int id,params string[] str);*/
    }
}