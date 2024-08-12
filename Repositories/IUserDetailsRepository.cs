using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<UserDetail>> GetAllUserDetails();
        Task<UserDetail> GetUserDetailsById(int id);
        Task Add(UserDetail userDetails);
        Task Update(UserDetail userDetails);
        Task Delete(int id);
    }
}
