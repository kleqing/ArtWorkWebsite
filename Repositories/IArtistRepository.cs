using BusinessObject;

namespace Repositories
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int id);
        Task Add(Artist artist);
        Task Update(Artist artist);
        Task Delete(int id);

    }
}
