using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FeedbackDAO : SingletonBase<FeedbackDAO>
    {
        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int userId, int artworkId)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.UserId == userId && f.ArtworkId == artworkId);
            if (feedback == null) return null;

            return feedback;
        }

        public async Task Add(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Feedback feedback)
        {
            var existingItem = await GetFeedbackById(feedback.UserId, feedback.ArtworkId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(feedback);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int userId, int artworkId)
        {
            var feedback = await GetFeedbackById(userId, artworkId);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
