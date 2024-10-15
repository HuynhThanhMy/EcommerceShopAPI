using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;

namespace EcommerceWebAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public CategoryViewModel Add(CategoryModel loai)
        {
            var _loai = new Category
            {
                CategoryName = loai.CategoryName
            };
            _context.Add(_loai);
            _context.SaveChanges();

            return new CategoryViewModel
            {
                CategoryId = _loai.CategoryId,
                CategoryName = _loai.CategoryName
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Categories.SingleOrDefault(lo => lo.CategoryId == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<CategoryViewModel> GetAll()
        {
            var loais = _context.Categories.Select(lo => new CategoryViewModel
            {
                CategoryId = lo.CategoryId,
                CategoryName = lo.CategoryName
            });
            return loais.ToList();
        }

        public CategoryViewModel GetById(int id)
        {
            var loai = _context.Categories.SingleOrDefault(lo => lo.CategoryId == id);
            if (loai != null)
            {
                return new CategoryViewModel
                {
                    CategoryId = loai.CategoryId,
                    CategoryName = loai.CategoryName
                };
            }
            return null;
        }

        public void Update(CategoryViewModel loai)
        {
            var _loai = _context.Categories.SingleOrDefault(lo => lo.CategoryId == loai.CategoryId);
            _loai.CategoryName = loai.CategoryName;
            _context.SaveChanges();
        }
    }
}
