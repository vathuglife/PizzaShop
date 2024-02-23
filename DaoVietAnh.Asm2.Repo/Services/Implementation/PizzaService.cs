using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private IEnumerable<Product>? _pizzas;
        private List<PizzaDTO>? _pizzasDTO;  
        private UnitOfWork? _unitOfWork;
        private PizzaServicePagingParameters? _pageConfig;
        public PizzaService()
        {
            InitializeObjects();
        }
        public Task<List<PizzaDTO>> GetAllPizzas(PizzaServicePagingParameters pageConfig)
        {
            return Task.Run(() =>
            {
                _pageConfig = pageConfig;
                GetAvailablePizzasFromDb();
                ConvertPizzasToPizzaDTOs();
                return _pizzasDTO!;
            });
            
        }
        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _pizzasDTO = new List<PizzaDTO>();  
        }
        private void GetAvailablePizzasFromDb()
        {
            int pageNumber = _pageConfig!.PageNumber;
            int pageSize = _pageConfig.PageSize;
            _pizzas = _unitOfWork!.ProductRepository!
                .Get()
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize);
        }
        private void ConvertPizzasToPizzaDTOs()
        {
            foreach (var pizza in _pizzas!)
            {
                Category category = _unitOfWork?.CategoryRepository!.GetByID(pizza.CategoryId!)!;
                PizzaDTO pizzaDTO = GetPizzaDTO(pizza, category);
                _pizzasDTO?.Add(pizzaDTO);
            }
        }
        private PizzaDTO GetPizzaDTO(Product pizza,Category category)
        {
            return new PizzaDTO
            {
                Name = pizza.ProductName,
                Category = category.CategoryName,
                Description = category.Description,
                Price = pizza.UnitPrice
            };
        }
        
    }
}
