using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [PrimaryKey(nameof(UserId), nameof(ArtworkId))]
    public class Feedback
    {
        public int UserId { get; set; }
        [Key]
        public int ArtworkId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
