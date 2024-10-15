using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;

namespace EcommerceWebAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddBookAsync(CategoryModel model)
        {
            var newBook = _mapper.Map<Category>(model);
            _context.Categories!.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.CategoryId;
        }

        public async Task DeleteBookAsync(int id)
        {
            var deleteBook = _context.Categories!.SingleOrDefault(b => b.CategoryId == id);
            if (deleteBook != null)
            {
                _context.Categories!.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryModel>> GetAllBooksAsync()
        {
            var books = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(books);
        }

        public async Task<CategoryModel> GetBookAsync(int id)
        {
            var book = await _context.Categories!.FindAsync(id);
            return _mapper.Map<CategoryModel>(book);
        }

        public async Task UpdateBookAsync(int id, CategoryModel model)
        {
            if (id == model.CategoryId)
            {
                var updateBook = _mapper.Map<Category>(model);
                _context.Categories!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
