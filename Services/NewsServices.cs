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
    public class NewsServices : INewsServices
    {
        private readonly HttpClient _httpClient;
        public NewsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(NewsDTO news)
        {
            await _httpClient.PostAsJsonAsync("New", news);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"New/{id}");
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNews()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<NewsDTO>>("New");
        }

        public async Task<NewsDTO> GetNewsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<NewsDTO>($"New/{id}");
        }

        public async Task Update(NewsDTO news)
        {
            await _httpClient.PutAsJsonAsync($"New/{news.Id}", news);
        }
    }
}
