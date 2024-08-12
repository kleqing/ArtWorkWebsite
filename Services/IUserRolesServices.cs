using ArtworkDTO;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{    public interface IUserRolesServices
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoles();
        Task<UserRoleDTO> GetUserRoleById(int userId, int roleId);
        Task Add(UserRoleDTO userRole);
        Task Update(UserRoleDTO userRole);
        Task Delete(int userId, int roleId);
    }
}
