using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArtworkDAO : SingletonBase<ArtworkDAO>
    {
        public async Task<IEnumerable<Artwork>> GetAllArtworks()
        {
            return await _context.Artworks.ToListAsync();
        }

        public async Task<Artwork> GetArtworkById(int id)
        {
            var artwork = await _context.Artworks.FirstOrDefaultAsync(a => a.Id == id);
            if (artwork == null) return null;

            return artwork;
        }

        public async Task Add(Artwork artwork)
        {
            await _context.Artworks.AddAsync(artwork);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Artwork artwork)
        {
            var existingItem = await GetArtworkById(artwork.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(artwork);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artwork = await GetArtworkById(id);
            if (artwork != null)
            {
                _context.Artworks.Remove(artwork);
                await _context.SaveChangesAsync();
            }
        }
    }
}
