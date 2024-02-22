using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public CustomerRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCustomer(int CustomerID)
        {
            Customer Customer = _dbContext?.Customers.Find(CustomerID)!;
            _dbContext?.Customers.Remove(Customer);
        }



        public Customer GetCustomerByID(int CustomerId)
        {
            return _dbContext!.Customers.Find(CustomerId)!;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext!.Customers.ToList();
        }

        public void InsertCustomer(Customer Customer)
        {
            _dbContext?.Customers.Add(Customer);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateCustomer(Customer Customer)
        {
            _dbContext!.Entry(Customer).State = EntityState.Modified;
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
