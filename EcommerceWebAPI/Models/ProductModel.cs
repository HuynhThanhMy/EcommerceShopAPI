using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    public class ProductModel : ProductViewModel
    {
        public Guid ProductId { get; set; }
    }
    public class ProductModel1
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }
}
