using ArtworkDTO;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly HttpClient _httpClient;
        public OrderDetailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(OrderDetailDTO orderDetail)
        {
            await _httpClient.PostAsJsonAsync("OrderDetail", orderDetail);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"OrderDetail/{id}");
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetails()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDetailDTO>>("OrderDetail");
        }

        public async Task<OrderDetailDTO> GetOrderDetailById(int id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetailDTO>($"OrderDetail/{id}");
        }

        public async Task Update(OrderDetailDTO orderDetail)
        {
            await _httpClient.PutAsJsonAsync($"OrderDetail/{orderDetail.OrderID}", orderDetail);
        }
    }
}
