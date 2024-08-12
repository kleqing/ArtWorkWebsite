using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.OrderDetailID == id);
            if (orderDetail == null) return null;

            return orderDetail;
        }

        public async Task Add(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OrderDetail orderDetail)
        {
            var existingItem = await GetOrderDetailById(orderDetail.OrderDetailID);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(orderDetail);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var orderDetail = await GetOrderDetailById(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
