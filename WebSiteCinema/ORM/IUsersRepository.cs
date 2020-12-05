using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<Users>> GetAllAsync();
        public Task<Users> GetByIdAsync(int id);
        public Task<Users> GetByLoginAsync(string login);
        public Task InsertAsync(Users user);
        public Task DeleteAsync(Users user);
        public Task DeleteAsync(int id);
        /*public Task UpdateAsync(int id,params string[] str);*/
    }
}