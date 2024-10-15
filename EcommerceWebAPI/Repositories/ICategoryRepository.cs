using EcommerceWebAPI.Models;
using EcommerceWebAPI.Data;

namespace EcommerceWebAPI.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> GetAllBooksAsync();
        public Task<CategoryModel> GetBookAsync(int id);
        public Task<int> AddBookAsync(CategoryModel model);
        public Task UpdateBookAsync(int id, CategoryModel model);
        public Task DeleteBookAsync(int id);
    }
}
