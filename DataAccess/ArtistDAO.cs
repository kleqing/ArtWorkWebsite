using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    namespace DataAccess
    {
        public class ArtistDAO : SingletonBase<ArtistDAO>
        {
            public async Task<IEnumerable<Artist>> GetAllArtists()
            {
                return await _context.Artists.ToListAsync();
            }

            public async Task<Artist> GetArtistById(int id)
            {
                var artist = await _context.Artists.FirstOrDefaultAsync(a => a.ArtistId == id);
                if (artist == null) return null;

                return artist;
            }

            public async Task Add(Artist artist)
            {
                await _context.Artists.AddAsync(artist);
                await _context.SaveChangesAsync();
            }

            public async Task Update(Artist artist)
            {
                var existingItem = await GetArtistById(artist.ArtistId);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(artist);
                }

                await _context.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
                var artist = await GetArtistById(id);
                if (artist != null)
                {
                    _context.Artists.Remove(artist);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }


