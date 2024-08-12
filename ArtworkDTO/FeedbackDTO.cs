using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkDTO
{
    public class FeedbackDTO
    {
        public int UserId { get; set; }
        public int ArtworkId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
