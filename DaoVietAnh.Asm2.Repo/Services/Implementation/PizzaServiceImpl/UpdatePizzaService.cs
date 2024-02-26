using AutoMapper;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class UpdatePizzaService
    {
        private UnitOfWork? _unitOfWork;
        private Mapper? _pizzaMapper;
        private UpdatePizzaDTO? _updatePizzaDTO;
        private Product? _pizza;

        public UpdatePizzaService() { InitializeObjects(); }
        public void Update(UpdatePizzaDTO updatePizzaDTO)
        {            
            _updatePizzaDTO = updatePizzaDTO;
            GetPizzaProductFromDbById(); ;
            MapUpdatePizzaDTOToPizzaProduct();
            UpdatePizzaProductIntoDB();

        }

        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _pizzaMapper = new Mapper(PizzaMapper.UpdatePizzaDTOToPizzaProduct());

        }
        private void GetPizzaProductFromDbById()
        {
            _pizza = _unitOfWork!.ProductRepository!.GetByID(_updatePizzaDTO!.Id);
        }
        private void MapUpdatePizzaDTOToPizzaProduct()
        {
            _pizza!.ProductName = _updatePizzaDTO!.Name;
            _pizza!.SupplierId = _updatePizzaDTO!.SupplierId;
            _pizza!.CategoryId = _updatePizzaDTO!.CategoryId;
            _pizza.QuantityPerUnit = GetQuantityPerUnitString(_updatePizzaDTO!.QuantityPerUnit);
            _pizza.UnitPrice = _updatePizzaDTO!.UnitPrice;
            _pizza.ProductImage = ImageUtils.ConvertImageStringToByteArray(
                _updatePizzaDTO.ProductImage!
                );
        }

        private void UpdatePizzaProductIntoDB()
        {
            _unitOfWork!.ProductRepository!.Update(_pizza!);
            _unitOfWork.Save();
        }

        private string GetQuantityPerUnitString(int quantity)
        {
            if (quantity == 1) return quantity + " piece";
            return quantity + " pieces";
        }
        private int GetLatestPizzaProductId()
        {
            Product latestPizza = _unitOfWork?.ProductRepository?
                .Get()
                .OrderByDescending(pizza => pizza.ProductId)
                .FirstOrDefault()!;
            if (latestPizza == null) return 0;
            int latestPizzaId = latestPizza.ProductId + 1;
            return latestPizzaId;
        }

        private int GetCategoryIdByCategoryName(string categoryName)
        {
            Category category = _unitOfWork!.CategoryRepository!
                .Get(category => category.CategoryName == categoryName)
                .FirstOrDefault()!;
            return category.CategoryId;
        }
        private int GetSupplierIdBySupplierName(string supplierName)
        {
            Supplier supplier = _unitOfWork!.SupplierRepository!
                .Get(supplier => supplier.CompanyName == supplierName)
                .FirstOrDefault()!;
            return supplier.SupplierId;
        }       
    }
}

