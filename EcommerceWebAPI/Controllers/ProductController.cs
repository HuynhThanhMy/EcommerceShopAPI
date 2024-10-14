using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<ProductModel> products = new List<ProductModel>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var product = products.SingleOrDefault(hh => hh.ProductId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Create(ProductViewModel ProductViewModel)
        {
            var product = new ProductModel
            {
                ProductId = Guid.NewGuid(),
                ProductName = ProductViewModel.ProductName,
                Price = ProductViewModel.Price
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, ProductModel productEdit)
        {
            try
            {
                // LINQ [Object] Query
                var product = products.SingleOrDefault(hh => hh.ProductId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                if (id != product.ProductId.ToString())
                {
                    return BadRequest();
                }
                // Update
                product.ProductName = productEdit.ProductName;
                product.Price = productEdit.Price;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                // LINQ [Object] Query
                var product = products.SingleOrDefault(hh => hh.ProductId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                // Update
                products.Remove(product);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
