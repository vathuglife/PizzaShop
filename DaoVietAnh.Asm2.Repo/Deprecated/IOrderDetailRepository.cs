using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface IOrderDetailRepository : IDisposable
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailByID(int OrderDetailId);
        void InsertOrderDetail(OrderDetail OrderDetail);
        void DeleteOrderDetail(int OrderDetailID);
        void UpdateOrderDetail(OrderDetail OrderDetail);
        void Save();
    }
}
