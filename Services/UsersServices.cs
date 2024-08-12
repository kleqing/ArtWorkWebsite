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
    public class UsersServices : IUsersServices
    {
        private readonly HttpClient _httpClient;
        public UsersServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(UserDTO user)
        {
            await _httpClient.PostAsJsonAsync("User", user);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"User/{id}");
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserDTO>>("User");
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<UserDTO>($"User/{id}");
        }

        public async Task Update(UserDTO user)
        {
            await _httpClient.PutAsJsonAsync($"User/{user.Id}", user);
        }
    }
}
