using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public OrderDetailRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrderDetail(int OrderDetailID)
        {
            OrderDetail OrderDetail = _dbContext?.OrderDetails.Find(OrderDetailID)!;
            _dbContext?.OrderDetails.Remove(OrderDetail);
        }



        public OrderDetail GetOrderDetailByID(int OrderDetailId)
        {
            return _dbContext!.OrderDetails.Find(OrderDetailId)!;
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _dbContext!.OrderDetails.ToList();
        }

        public void InsertOrderDetail(OrderDetail OrderDetail)
        {
            _dbContext?.OrderDetails.Add(OrderDetail);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail OrderDetail)
        {
            _dbContext!.Entry(OrderDetail).State = EntityState.Modified;
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
