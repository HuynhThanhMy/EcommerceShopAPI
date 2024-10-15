using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<ProductModel1> GetAll(string search, double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.Products.Include(hh => hh.Category).AsQueryable();
            //var allProducts = _context.Products.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.ProductName.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price <= to);
            }
            #endregion


            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.ProductName);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(hh => hh.ProductName); break;
                    case "gia_asc": allProducts = allProducts.OrderBy(hh => hh.Price); break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(hh => hh.Price); break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion



            //var result = allProducts.Select(hh => new ProductModel1
            //{
            //    ProductId = hh.ProductId,
            //    ProductName = hh.ProductName,
            //    Price = hh.Price,
            //    CategoryName = hh.Category.CategoryName
            //});

            //return result.ToList();

            var result = PaginatedList<EcommerceWebAPI.Data.Product>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(hh => new ProductModel1
            {
                ProductId = hh.ProductId,
                ProductName = hh.ProductName,
                Price = hh.Price,
                 CategoryName = hh.Category?.CategoryName
            }).ToList();
        }
    }
}
