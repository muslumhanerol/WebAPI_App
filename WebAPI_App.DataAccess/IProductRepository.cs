//CRUD INTERFACE
using WebAPI_App.Entities;
namespace WebAPI_App.DataAccess
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();

    }
}