using Microsoft.EntityFrameworkCore;
using WebAPI_App.Entities;

namespace WebAPI_App.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            Save();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}