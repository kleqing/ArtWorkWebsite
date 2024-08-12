using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IArtworkRepository
    {
        Task<IEnumerable<Artwork>> GetAllArtworks();
        Task<Artwork> GetArtworkById(int id);
        Task Add(Artwork artwork);
        Task Update(Artwork artwork);
        Task Delete(int id);
    }
}
