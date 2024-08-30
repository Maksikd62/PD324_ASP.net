using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;

namespace PD324_01.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _context;


        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category? GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.AsNoTracking();
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = GetById(id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

    }
}
