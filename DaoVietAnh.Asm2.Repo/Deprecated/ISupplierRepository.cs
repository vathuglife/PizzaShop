using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface ISupplierRepository : IDisposable
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplierByID(int SupplierId);
        void InsertSupplier(Supplier Supplier);
        void DeleteSupplier(int SupplierID);
        void UpdateSupplier(Supplier Supplier);
        void Save();
    }
}
