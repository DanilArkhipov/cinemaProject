using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using WebSiteCinema.Models;

namespace ORM
{
    public class OrderRepository:UnitOfWork,IOrderRepository
    {
        private IOrderRepository _orderRepositoryImplementation;

        public OrderRepository(LinqToDbConnectionOptions<UnitOfWork> options) : base(options)
        {
        }

        private ITable<Order> Order => GetTable<Order>();
        public async Task<IEnumerable<Order>> GetAllByUserLoginAsync(string user_login)
        {
            return await Order.Where(o => o.user_login == user_login).ToListAsync();
        }

        public async Task<Order> GetAsync(Order order)
        {
            return await Order.Where(o =>
                o.code == order.code &&
                o.created == order.created &&
                o.user_login == order.user_login &&
                o.place_id == order.place_id).FirstOrDefaultAsync();
        }

        public async Task<Order> GetAsync(string code)
        {
            return await Order.Where(o => o.code == code).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Order order)
        {
            await Order.InsertWithInt32IdentityAsync(() => new Order
            {
                place_id = order.place_id,
                code = order.code,
                created = order.created,
                user_login = order.user_login,
            });
        }
    }
}