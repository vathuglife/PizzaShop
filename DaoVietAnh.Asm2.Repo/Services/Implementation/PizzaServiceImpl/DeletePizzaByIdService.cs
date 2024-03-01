using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class DeletePizzaByIdService
    {
        private IUnitOfWork? _unitOfWork;
        private Product? _pizza;
        private int  _id;
        public DeletePizzaByIdService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            _id = id;
            GetPizzaProductById();
            DeletePizzaProduct();
        }
        private void GetPizzaProductById()
        {
            _pizza = _unitOfWork!.ProductRepository!.GetByID(_id);
        }
        private void DeletePizzaProduct()
        {
            _unitOfWork!.ProductRepository!.Delete(_pizza!);
            _unitOfWork.Save();
        }      
    }
}
