namespace EcommerceWebAPI.Data
{
    public enum OrderStatus
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }

    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDelivery { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Consignee { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
