using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAllByUserLoginAsync(string user_login);
        public Task<Order> GetAsync(Order order);
        public Task<Order> GetAsync(string code);
        public Task InsertAsync(Order order);
    }
}