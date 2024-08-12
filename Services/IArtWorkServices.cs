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
    public interface IArtworkServices
    {
        Task<IEnumerable<ArtworksDTO>> GetAllArtworks();
        Task<ArtworksDTO> GetArtworkById(int id);
        Task Add(ArtworksDTO artwork);
        Task Update(ArtworksDTO artwork);
        Task Delete(int id);
    }
}
