using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RolesRepository : IRolesRepository
    {
        public async Task Add(Role role)
        {
            await RolesDAO.Instance.Add(role);
        }

        public async Task Delete(int id)
        {
            await RolesDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await RolesDAO.Instance.GetAllRoles();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await RolesDAO.Instance.GetRoleById(id);
        }

        public async Task Update(Role role)
        {
            await RolesDAO.Instance.Update(role);
        }
    }
}
