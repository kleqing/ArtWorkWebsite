using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRolesDAO : SingletonBase<UserRolesDAO>
    {

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetUserRoleById(int userId, int roleId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole == null) return null;

            return userRole;
        }

        public async Task Add(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserRole userRole)
        {
            var existingItem = await GetUserRoleById(userRole.UserId, userRole.RoleId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(userRole);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int userId, int roleId)
        {
            var userRole = await GetUserRoleById(userId, roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }
    }
}
