using PD324_01.Models;

namespace PD324_01.Repositories
{
    public interface ICategoryRepository
    {
        Category? GetById(int id);
        IEnumerable<Category> GetAll();
        void Add(Category category);
        void Delete(int id);
        void Update(Category category);
    }
}
