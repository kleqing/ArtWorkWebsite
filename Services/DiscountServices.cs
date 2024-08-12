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
    public class DiscountServices : IDiscountServices
    {
        private readonly HttpClient _httpClient;
        public DiscountServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Add(DiscountDTO discount)
        {
            await _httpClient.PostAsJsonAsync("Discount", discount);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"Discount/{id}");
        }

        public async Task<IEnumerable<DiscountDTO>> GetAllDiscounts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DiscountDTO>>("Discount");
        }

        public async Task<DiscountDTO> GetDiscountById(int id)
        {
            return await _httpClient.GetFromJsonAsync<DiscountDTO>($"Discount/{id}");
        }

        public async Task Update(DiscountDTO discount)
        {
            await _httpClient.PutAsJsonAsync($"odata/Artists/{discount.Id}", discount);
        }
    }
}
