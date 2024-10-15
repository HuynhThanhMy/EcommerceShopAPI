using EcommerceWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _hangHoaResposity;

        public ProductsController(IProductRepository hangHoaResposity)
        {
            _hangHoaResposity = hangHoaResposity;
        }

        [HttpGet]
        public IActionResult GettAllProducts(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            try
            {
                var result = _hangHoaResposity.GetAll(search, from, to, sortBy);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
    }
}
