using PD324_01.Models;

namespace PD324_01.Repositories
{
    public interface IProductRepository
    {
        Product? GetById(int? id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
    }
}
