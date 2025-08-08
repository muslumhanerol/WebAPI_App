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
                _repo.Delete(p);
                _repo.Save();
            }
        }


        public List<Product> GetAll() => _repo.GetAll();


        public Product? GetById(int id) => _repo.GetById(id);


        public void Update(Product product)
        {
            var existing = _repo.GetById(product.Id); //producttan gelen id bilgisini kontrol et
            if (existing == null) throw new Exception("Bulunamadı");
            existing.Name = product.Name; // gelen productın name bilgisini, mevcut olanın name bilgisi ile değiştir
            existing.Price = product.Price; // gelen productın price bilgisini, mevcut olanın price bilgisi ile değiştir
            _repo.Update(existing); //repodaki updateyi çağır bunu içerisindeki değiştiğin bilgileri at.
            _repo.Save(); //değişiklikleri kaydet
        }
    }

}
