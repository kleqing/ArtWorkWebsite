using BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace ArtworkDTO
{
    public class ArtistDTO
    {
        public int ArtistId { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ArtworksDTO>? Artworks { get; set; }

    }
}
