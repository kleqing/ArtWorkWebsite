using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class NewsRepository : INewsRepository
    {
        public async Task Add(News news)
        {
            await NewsDAO.Instance.Add(news);
        }

        public async Task Delete(int id)
        {
            await NewsDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            return await NewsDAO.Instance.GetAllNews();
        }

        public async Task<News> GetNewsById(int id)
        {
            return await NewsDAO.Instance.GetNewsById(id);
        }

        public async Task Update(News news)
        {
            await NewsDAO.Instance.Update(news);
        }
    }
}
