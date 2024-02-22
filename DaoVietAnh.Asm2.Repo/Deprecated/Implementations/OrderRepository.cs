using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public OrderRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrder(int OrderID)
        {
            Order Order = _dbContext?.Orders.Find(OrderID)!;
            _dbContext?.Orders.Remove(Order);
        }



        public Order GetOrderByID(int OrderId)
        {
            return _dbContext!.Orders.Find(OrderId)!;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext!.Orders.ToList();
        }

        public void InsertOrder(Order Order)
        {
            _dbContext?.Orders.Add(Order);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateOrder(Order Order)
        {
            _dbContext!.Entry(Order).State = EntityState.Modified;
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
