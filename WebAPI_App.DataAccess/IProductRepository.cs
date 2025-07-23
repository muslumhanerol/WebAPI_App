using WebAPI_App.Entities;

namespace WebAPI_App.DataAccess
{
    public interface IProductRepository
    {
        List<Product> GetAll();

    }
}