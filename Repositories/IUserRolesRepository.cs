using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRolesRepository
    {
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleById(int userId, int roleId);
        Task Add(UserRole userRole);
        Task Update(UserRole userRole);
        Task Delete(int userId, int roleId);
    }
}
