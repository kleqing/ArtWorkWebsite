using ArtworkDTO;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRolesServices
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleById(int id);
        Task Add(RoleDTO role);
        Task Update(RoleDTO role);
        Task Delete(int id);
    }
}
