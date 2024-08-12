using ArtworkDTO;
using BusinessObject;
using Repositories;
using System.Net.Http.Json;

namespace Services
{
    public class ArtworkServices : IArtworkServices
    {
        private readonly HttpClient _httpClient;
        public ArtworkServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(ArtworksDTO artwork)
        {
            await _httpClient.PostAsJsonAsync("Artwork", artwork);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"Artwork/{id}");
        }

        public async Task<IEnumerable<ArtworksDTO>> GetAllArtworks()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ArtworksDTO>>("Artwork");
        }

        public async Task<ArtworksDTO> GetArtworkById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ArtworksDTO>($"Artwork/{id}");
        }

        public async Task Update(ArtworksDTO artwork)
        {
            await _httpClient.PutAsJsonAsync($"Artwork/{artwork.Id}", artwork);
        }
    }
}
