using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.DAL
{
    public class UnitOfWork : IDisposable
    {

        private ShoppingWebsiteDBContext? _dbContext = new ShoppingWebsiteDBContext();
        private bool disposed = false;
        private GenericRepository<Account>? _accountRepository;
        private GenericRepository<Category>? _categoryRepository;
        private GenericRepository<Customer>? _customerRepository;
        private GenericRepository<Order>? _orderRepository;
        private GenericRepository<OrderDetail>? _orderDetailRepository;
        private GenericRepository<Product>? _productRepository;
        private GenericRepository<Supplier>? _supplierRepository;

        public ShoppingWebsiteDBContext? DbContext { get => _dbContext; set => _dbContext = value; }
        public bool Disposed { get => disposed; set => disposed = value; }
        public GenericRepository<Account>? AccountRepository
        {
            get
                {
                if (_accountRepository == null)
                {
                    _accountRepository = new GenericRepository<Account>(_dbContext!);
                }
                return _accountRepository;
            }
            set => _accountRepository = value;
        }
        public GenericRepository<Category>? CategoryRepository {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_dbContext!);
                }
                return _categoryRepository;
            } set => _categoryRepository = value; }
        public GenericRepository<Customer>? CustomerRepository {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_dbContext!);
                }
                return _customerRepository;
            } set => _customerRepository = value; }
        public GenericRepository<Order>? OrderRepository {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new GenericRepository<Order>(_dbContext!);
                }
                return _orderRepository;
            } set => _orderRepository = value; }
        public GenericRepository<OrderDetail>? OrderDetailRepository {
            get
            {
                if (_orderDetailRepository == null)
                {
                    _orderDetailRepository = new GenericRepository<OrderDetail>(_dbContext!);
                }
                return _orderDetailRepository;
            } set => _orderDetailRepository = value; }
        public GenericRepository<Product>? ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new GenericRepository<Product>(_dbContext!);
                }
                return _productRepository;
            }
            set => _productRepository = value; }
        public GenericRepository<Supplier>? SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new GenericRepository<Supplier>(_dbContext!);
                }
                return _supplierRepository;
            }
            set => _supplierRepository = value; }
        
        public void Save()
        {
            _dbContext?.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext?.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
