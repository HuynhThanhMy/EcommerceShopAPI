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

    //public class HangHoaVM
    //{
    //    public string TenHangHoa { get; set; }
    //    public double DonGia { get; set; }
    //}

    //public class HangHoa : HangHoaVM
    //{
    //    public Guid MaHangHoa { get; set; }
    //}
}
