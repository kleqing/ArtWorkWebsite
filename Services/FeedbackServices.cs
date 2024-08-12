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
    public class FeedbackServices : IFeedbackServices
    {
        private readonly HttpClient _httpClient;
        public FeedbackServices(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task Add(FeedbackDTO feedback)
        {
            await _httpClient.PostAsJsonAsync("Feedback", feedback);
        }

        public async Task Delete(int userId, int artworkId)
        {
            await _httpClient.DeleteAsync($"Feedback/{userId}/{artworkId}");
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacks()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FeedbackDTO>>("Feedback");
        }

        public async Task<FeedbackDTO> GetFeedbackById(int userId, int artworkId)
        {
            return await _httpClient.GetFromJsonAsync<FeedbackDTO>($"Feedback/{userId}/{artworkId}");
        }

        public async Task Update(FeedbackDTO feedback)
        {
            await _httpClient.PutAsJsonAsync($"Feedback/{feedback.UserId}", feedback);
        }
    }
}
