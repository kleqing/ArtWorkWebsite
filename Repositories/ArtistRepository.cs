using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        public async Task Add(Artist artist)
        {
            await ArtistDAO.Instance.Add(artist);
        }

        public async Task Delete(int id)
        {
            await ArtistDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await ArtistDAO.Instance.GetAllArtists();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await ArtistDAO.Instance.GetArtistById(id);
        }

        public async Task Update(Artist artist)
        {
            await ArtistDAO.Instance.Update(artist);
        }
    }
}
