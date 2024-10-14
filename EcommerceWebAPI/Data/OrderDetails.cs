using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EcommerceWebAPI.Data
{
    public class OrderDetails
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }

        //relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
