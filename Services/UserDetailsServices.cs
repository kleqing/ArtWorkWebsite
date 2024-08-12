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
    public class UserDetailsServices : IUserDetailsServices
    {
        private readonly HttpClient _httpClient;
        public UserDetailsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(UserDetailDTO userDetails)
        {
            await _httpClient.PostAsJsonAsync("UserDetail", userDetails);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"UserDetail/{id}");
        }

        public async Task<IEnumerable<UserDetailDTO>> GetAllUserDetails()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserDetailDTO>>("UserDetail");
        }

        public async Task<UserDetailDTO> GetUserDetailsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<UserDetailDTO>($"UserDetail/{id}");
        }

        public async Task Update(UserDetailDTO userDetails)
        {
            await _httpClient.PutAsJsonAsync($"UserDetail/{userDetails.UserId}", userDetails);
        }
    }
}
