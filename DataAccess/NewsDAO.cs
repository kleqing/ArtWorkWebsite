using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsDAO : SingletonBase<NewsDAO>
    {
        public async Task<IEnumerable<News>> GetAllNews()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null) return null;

            return news;
        }

        public async Task Add(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
        }

        public async Task Update(News news)
        {
            var existingItem = await GetNewsById(news.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(news);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var news = await GetNewsById(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
        }
    }
}
