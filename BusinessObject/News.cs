using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class News
    {
        public int Id { get; set; }
        public int ArtworkID {  get; set; }
        public string Title { get; set;}
        public string Description { get; set;}
        public string Author { get; set;}

    }
}
