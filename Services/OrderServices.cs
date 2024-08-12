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
    public class OrderServices : IOrderServices
    {
        private readonly HttpClient _httpClient;
        public OrderServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(OrderDTO order)
        {
            await _httpClient.PostAsJsonAsync("Order", order);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"Order/{id}");
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDTO>>("Order");
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDTO>($"Order/{id}");
        }

        public async Task Update(OrderDTO order)
        {
            await _httpClient.PutAsJsonAsync($"Order/{order.OrderId}", order);
        }
    }
}
