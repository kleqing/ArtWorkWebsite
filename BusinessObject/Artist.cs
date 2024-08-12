using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string FullName { get; set;}
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ? Bio { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Artwork> ? Artworks { get; set; }
    }
}
