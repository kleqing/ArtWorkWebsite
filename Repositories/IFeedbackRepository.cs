using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int userId, int artworkId);
        Task Add(Feedback feedback);
        Task Update(Feedback feedback);
        Task Delete(int userId, int artworkId);
    }
}
