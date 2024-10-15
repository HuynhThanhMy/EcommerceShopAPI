using EcommerceWebAPI.Models;

namespace EcommerceWebAPI.Services
{
    public class CategoryRepositoryMemory : ICategoryRepository
    {
        static List<CategoryViewModel> loais = new List<CategoryViewModel>
        {
            new CategoryViewModel{CategoryId = 1, CategoryName = "Tivi"},
            new CategoryViewModel{CategoryId = 2, CategoryName = "Tủ lạnh"},
            new CategoryViewModel{CategoryId = 3, CategoryName = "Điều hòa"},
            new CategoryViewModel{CategoryId = 4, CategoryName = "Máy giặt"},
        };

        public CategoryViewModel Add(CategoryModel loai)
        {
            var _loai = new CategoryViewModel
            {
                CategoryId = loais.Max(lo => lo.CategoryId) + 1,
                CategoryName = loai.CategoryName
            };
            loais.Add(_loai);
            return _loai;
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(lo => lo.CategoryId == id);
            loais.Remove(_loai);
        }

        public List<CategoryViewModel> GetAll()
        {
            return loais;
        }

        public CategoryViewModel GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.CategoryId == id);
        }

        public void Update(CategoryViewModel loai)
        {
            var _loai = loais.SingleOrDefault(lo => lo.CategoryId == loai.CategoryId);
            if (_loai != null)
            {
                _loai.CategoryName = loai.CategoryName;
            }

        }
    }
}
