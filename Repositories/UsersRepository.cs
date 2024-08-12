using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public async Task Add(User user)
        {
            await UsersDAO.Instance.Add(user);
        }

        public async Task Delete(int id)
        {
            await UsersDAO.Instance.Delete(id);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return UsersDAO.Instance.GetAllUsers();
        }

        public Task<User> GetUserById(int id)
        {
            return UsersDAO.Instance.GetUserById(id);
        }

        public async Task Update(User user)
        {
            await UsersDAO.Instance.Update(user);
        }
    }
}
