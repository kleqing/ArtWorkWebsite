using ArtworkDTO;
using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int id);
        Task Add(OrderDTO order);
        Task Update(OrderDTO order);
        Task Delete(int id);
    }
}
