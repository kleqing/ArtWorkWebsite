namespace BusinessObject
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderedDate { get; set; }
        public int Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public double Price { get; set; }
        public virtual ICollection<OrderDetail> ? OrderDetail { get; set; }
    }
}
