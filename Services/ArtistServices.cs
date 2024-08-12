using ArtworkDTO;
using BusinessObject;
using System.Net.Http.Json;

namespace Services
{
    public class ArtistServices : IArtistServices
    {
        private readonly HttpClient _httpClient;
        public ArtistServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(ArtistDTO artist)
        {
            await _httpClient.PostAsJsonAsync("Artist", artist);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"Artist/{id}");
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllArtists()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ArtistDTO>>("Artist");
        }

        public async Task<ArtistDTO> GetArtistById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ArtistDTO>($"Artist/{id}");
        }

        public async Task Update(ArtistDTO artist)
        {
            await _httpClient.PutAsJsonAsync($"Artist/{artist.ArtistId}", artist);
        }
    }
}
