using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        public async Task Add(UserRole userRole)
        {
            await UserRolesDAO.Instance.Add(userRole);
        }

        public async Task Delete(int userId, int roleId)
        {
            await UserRolesDAO.Instance.Delete(userId, roleId);
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await UserRolesDAO.Instance.GetAllUserRoles();
        }

        public async Task<UserRole> GetUserRoleById(int userId, int roleId)
        {
            return await UserRolesDAO.Instance.GetUserRoleById(userId, roleId);
        }

        public async Task Update(UserRole userRole)
        {
            await UserRolesDAO.Instance.Update(userRole);
        }
    }
}
