using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDetailsDAO : SingletonBase<UserDetailsDAO>
    {

        public async Task<IEnumerable<UserDetail>> GetAllUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> GetUserDetailsById(int id)
        {
            var userDetails = await _context.UserDetails.FirstOrDefaultAsync(ud => ud.UserDetailId == id);
            if (userDetails == null) return null;

            return userDetails;
        }

        public async Task Add(UserDetail userDetails)
        {
            await _context.UserDetails.AddAsync(userDetails);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserDetail userDetails)
        {
            var existingItem = await GetUserDetailsById(userDetails.UserDetailId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(userDetails);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userDetails = await GetUserDetailsById(id);
            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}
