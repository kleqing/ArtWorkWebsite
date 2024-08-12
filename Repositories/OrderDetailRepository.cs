using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task Add(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.Add(orderDetail);
        }

        public async Task Delete(int id)
        {
            await OrderDetailDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await OrderDetailDAO.Instance.GetAllOrderDetails();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailById(id);
        }

        public async Task Update(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.Update(orderDetail);
        }
    }
}
