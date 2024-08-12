using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task Add(Order order)
        {
            await OrderDAO.Instance.Add(order);
        }

        public async Task Delete(int id)
        {
            await OrderDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await OrderDAO.Instance.GetAllOrders();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await OrderDAO.Instance.GetOrderById(id);
        }

        public async Task Update(Order order)
        {
            await OrderDAO.Instance.Update(order);
        }
    }
}
