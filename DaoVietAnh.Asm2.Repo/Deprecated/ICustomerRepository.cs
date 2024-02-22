using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int CustomerId);
        void InsertCustomer(Customer Customer);
        void DeleteCustomer(int CustomerID);
        void UpdateCustomer(Customer Customer);
        void Save();
    }
}
