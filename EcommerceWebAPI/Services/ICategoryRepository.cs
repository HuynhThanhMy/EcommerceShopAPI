using EcommerceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Services
{
    public interface ICategoryRepository
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Add(CategoryModel loai);
        void Update(CategoryViewModel loai);
        void Delete(int id);
    }
}
