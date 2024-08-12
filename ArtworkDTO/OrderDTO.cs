using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkDTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderedDate { get; set; }
        public int Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public double Price { get; set; }
    }
}
