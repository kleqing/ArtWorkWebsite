using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RolesDAO : SingletonBase<RolesDAO>
    {

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if (role == null) return null;

            return role;
        }

        public async Task Add(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Role role)
        {
            var existingItem = await GetRoleById(role.RoleId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(role);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var role = await GetRoleById(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
