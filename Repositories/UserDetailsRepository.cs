using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        public async Task Add(UserDetail userDetails)
        {
            await UserDetailsDAO.Instance.Add(userDetails);
        }

        public async Task Delete(int id)
        {
            await UserDetailsDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetails()
        {
            return await UserDetailsDAO.Instance.GetAllUserDetails();
        }

        public async Task<UserDetail> GetUserDetailsById(int id)
        {
            return await UserDetailsDAO.Instance.GetUserDetailsById(id);
        }

        public async Task Update(UserDetail userDetails)
        {
            await UserDetailsDAO.Instance.Update(userDetails);
        }
    }
}
