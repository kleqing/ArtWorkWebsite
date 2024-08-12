using ArtworkDTO;
using BusinessObject;

namespace Services
{
    public interface IArtistServices
    {
        Task<IEnumerable<ArtistDTO>> GetAllArtists();
        Task<ArtistDTO> GetArtistById(int id);
        Task Add(ArtistDTO artist);
        Task Update(ArtistDTO artist);
        Task Delete(int id);

    }
}
