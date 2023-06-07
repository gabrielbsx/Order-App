using OrderApp.Domain.Interfaces;

namespace OrderApp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Consumer Consumer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalValue { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            CreatedAt = DateTime.UtcNow;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Sent,
        Delivered,
        Canceled,
    }
}
