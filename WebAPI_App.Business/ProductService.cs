using WebAPI_App.DataAccess;
using WebAPI_App.Entities;

namespace WebAPI_App.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;

        public void Add(Product product)
        {
            _repo.Add(product);
            _repo.Save();
        }

        public void Delete(int id)
        {
            var p = _repo.GetById(id); //repo üzerinden id yi kontrol et, 
            if (p != null) //eşlesen varsa
            {
                throw new ArgumentException($"Product with id {id} not found.");
            }
            _repo.Delete(p);
            _repo.Save();
        }
        {
        

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }

}
