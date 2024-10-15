using EcommerceWebAPI.Models;

namespace EcommerceWebAPI.Services
{
    public interface IProductRepository
    {
        List<ProductModel1> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
    }
}
