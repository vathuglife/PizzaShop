using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public ProductRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProduct(int ProductID)
        {
            Product Product = _dbContext?.Products.Find(ProductID)!;
            _dbContext?.Products.Remove(Product);
        }



        public Product GetProductByID(int ProductId)
        {
            return _dbContext!.Products.Find(ProductId)!;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext!.Products.ToList();
        }

        public void InsertProduct(Product Product)
        {
            _dbContext?.Products.Add(Product);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateProduct(Product Product)
        {
            _dbContext!.Entry(Product).State = EntityState.Modified;
        }
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
            }
            disposed = true;
        }
    }
}
