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
    public class RolesServices : IRolesServices
    {
        private readonly HttpClient _httpClient;
        public RolesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(RoleDTO role)
        {
            await _httpClient.PostAsJsonAsync("Role", role);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"Role/{id}");
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<RoleDTO>>("Role");
        }

        public async Task<RoleDTO> GetRoleById(int id)
        {
            return await _httpClient.GetFromJsonAsync<RoleDTO>($"Role/{id}");
        }

        public async Task Update(RoleDTO role)
        {
            await _httpClient.PutAsJsonAsync($"Role/{role.RoleId}", role);
        }
    }
}
