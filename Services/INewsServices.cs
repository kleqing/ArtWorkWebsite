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
    public interface INewsServices
    {
        Task<IEnumerable<NewsDTO>> GetAllNews();
        Task<NewsDTO> GetNewsById(int id);
        Task Add(NewsDTO news);
        Task Update(NewsDTO news);
        Task Delete(int id);
    }
}
