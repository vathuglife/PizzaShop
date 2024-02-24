using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using DaoVietAnh.Asm2.Repo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class GetAllPizzaService
    {
        private IEnumerable<Product>? _pizzas;
        private List<PizzaDTO>? _pizzasDTOs;
        private UnitOfWork? _unitOfWork;
        private PizzaServicePagingParameters? _pageConfig;
        public GetAllPizzaService()
        {
            InitializeObjects();
        }
        public async Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingParameters pageConfig)
        {
            await Task.Run(() =>
            {
                _pageConfig = pageConfig;
                GetAvailablePizzasFromDb();
                ConvertPizzasToPizzaDTOs();
            });
            return GetSuccessfulAllPizzaRetrievalResult();

        }
        
        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _pizzasDTOs = new List<PizzaDTO>();
        }
        private void GetAvailablePizzasFromDb()
        {
            int pageNumber = _pageConfig!.PageNumber;
            int pageSize = _pageConfig.PageSize;
            _pizzas = _unitOfWork!.ProductRepository!
                .Get()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
        private void ConvertPizzasToPizzaDTOs()
        {
            foreach (var pizza in _pizzas!)
            {
                Category category = _unitOfWork?.CategoryRepository!.GetByID(pizza.CategoryId!)!;
                PizzaDTO pizzaDTO = GetPizzaDTO(pizza, category);
                _pizzasDTOs?.Add(pizzaDTO);
            }
        }
        private PizzaDTO GetPizzaDTO(Product pizza, Category category)
        {

            return new PizzaDTO
            {
                Id = pizza.ProductId,
                Name = pizza.ProductName,
                Category = category.CategoryName,
                Description = category.Description,
                Price = pizza.UnitPrice,
                Image = ImageUtils.GetBase64ImageFromByteArray(pizza.ProductImage!)

            };
        }        
        private PizzaServiceResponse GetSuccessfulAllPizzaRetrievalResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "",
                ReturnData = _pizzasDTOs
            };
        }
      

    }
}
