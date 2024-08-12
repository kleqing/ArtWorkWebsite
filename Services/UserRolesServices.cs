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
    public class UserRolesServices : IUserRolesServices
    {
        private readonly HttpClient _httpClient;
        public UserRolesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(UserRoleDTO userRole)
        {
            await _httpClient.PostAsJsonAsync("UserRole", userRole);
        }

        public async Task Delete(int userId, int roleId)
        {
            await _httpClient.DeleteAsync($"UserRole/{userId}/{roleId}");
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoles()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserRoleDTO>>("UserRole");
        }

        public async Task<UserRoleDTO> GetUserRoleById(int userId, int roleId)
        {
            return await _httpClient.GetFromJsonAsync<UserRoleDTO>($"UserRole/{userId}/{roleId}");
        }

        public async Task Update(UserRoleDTO userRole)
        {
            await _httpClient.PutAsJsonAsync($"UserRole/{userRole.RoleId}", userRole);
        }
    }
}
