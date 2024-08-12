using ArtworkDTO;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserDetailsServices
    {
        Task<IEnumerable<UserDetailDTO>> GetAllUserDetails();
        Task<UserDetailDTO> GetUserDetailsById(int id);
        Task Add(UserDetailDTO userDetails);
        Task Update(UserDetailDTO userDetails);
        Task Delete(int id);
    }
}
