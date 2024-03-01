using DaoVietAnh.Asm2.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Customer> CustomerRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Supplier> SupplierRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        void Save();
    }
}
