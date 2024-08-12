using ArtworkDTO;
using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFeedbackServices
    {
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbacks();
        Task<FeedbackDTO> GetFeedbackById(int userId, int artworkId);
        Task Add(FeedbackDTO feedback);
        Task Update(FeedbackDTO feedback);
        Task Delete(int userId, int artworkId);
    }
}
