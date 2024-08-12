using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public async Task Add(Feedback feedback)
        {
            await FeedbackDAO.Instance.Add(feedback);
        }

        public async Task Delete(int userId, int artworkId)
        {
            await FeedbackDAO.Instance.Delete(userId, artworkId);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await FeedbackDAO.Instance.GetAllFeedbacks();
        }

        public async Task<Feedback> GetFeedbackById(int userId, int artworkId)
        {
            return await FeedbackDAO.Instance.GetFeedbackById(userId, artworkId);
        }

        public async Task Update(Feedback feedback)
        {
            await FeedbackDAO.Instance.Update(feedback);
        }
    }
}
