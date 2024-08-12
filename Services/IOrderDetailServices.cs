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
    public interface IOrderDetailServices
    {
        Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetails();
        Task<OrderDetailDTO> GetOrderDetailById(int id);
        Task Add(OrderDetailDTO orderDetail);
        Task Update(OrderDetailDTO orderDetail);
        Task Delete(int id);
    }
}
