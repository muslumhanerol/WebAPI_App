using WebAPI_App.Entities;

namespace WebAPI_App.Business
{


    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}