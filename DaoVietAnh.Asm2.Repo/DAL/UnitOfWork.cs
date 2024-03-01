using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        private IGenericRepository<Account>? _accountRepository;
        private IGenericRepository<Category>? _categoryRepository;
        private IGenericRepository<Customer>? _customerRepository;
        private IGenericRepository<Order>? _orderRepository;
        private IGenericRepository<OrderDetail>? _orderDetailRepository;
        private IGenericRepository<Product>? _productRepository;
        private IGenericRepository<Supplier>? _supplierRepository;

        public UnitOfWork(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Account> AccountRepository
        {
            get
            {
                return _accountRepository ??= new GenericRepository<Account>(_dbContext!);
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository ??= new GenericRepository<Product>(_dbContext!);
            }
        }

        public IGenericRepository<Customer> CustomerRepository
        {
            get
            {
                return _customerRepository ??= new GenericRepository<Customer>(_dbContext!);
            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new GenericRepository<Category>(_dbContext!);
            }
        }
        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                return _orderRepository ??= new GenericRepository<Order>(_dbContext!);
            }
        }
        public IGenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                return _orderDetailRepository ??= new GenericRepository<OrderDetail>(_dbContext!);
            }
        }
        public IGenericRepository<Supplier> SupplierRepository
        {
            get
            {
                return _supplierRepository ??= new GenericRepository<Supplier>(_dbContext!);
            }
        }
        public void Save()
        {
            _dbContext!.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext!.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
