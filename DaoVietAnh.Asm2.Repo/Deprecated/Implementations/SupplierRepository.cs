using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class SupplierRepository : ISupplierRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public SupplierRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteSupplier(int SupplierID)
        {
            Supplier Supplier = _dbContext?.Suppliers.Find(SupplierID)!;
            _dbContext?.Suppliers.Remove(Supplier);
        }



        public Supplier GetSupplierByID(int SupplierId)
        {
            return _dbContext!.Suppliers.Find(SupplierId)!;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _dbContext!.Suppliers.ToList();
        }

        public void InsertSupplier(Supplier Supplier)
        {
            _dbContext?.Suppliers.Add(Supplier);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateSupplier(Supplier Supplier)
        {
            _dbContext!.Entry(Supplier).State = EntityState.Modified;
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
