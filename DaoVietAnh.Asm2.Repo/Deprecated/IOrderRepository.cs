using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int OrderId);
        void InsertOrder(Order Order);
        void DeleteOrder(int OrderID);
        void UpdateOrder(Order Order);
        void Save();
    }
}
