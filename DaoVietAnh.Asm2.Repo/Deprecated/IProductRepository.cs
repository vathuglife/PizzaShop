using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductId);
        void InsertProduct(Product Product);
        void DeleteProduct(int ProductID);
        void UpdateProduct(Product Product);
        void Save();
    }
}
