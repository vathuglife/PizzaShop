﻿using AutoMapper;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Utils;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class InsertPizzaService
    {

        private IUnitOfWork? _unitOfWork;
        private Mapper? _pizzaMapper;
        private NewPizzaDTO? _newPizzaDTO;
        private Product? _pizza;

        public InsertPizzaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; InitializeObjects();
        }
        public void Insert(NewPizzaDTO newPizzaDTO)
        {
            _newPizzaDTO = newPizzaDTO;
            MapNewPizzaDTOToPizzaProduct();
            InsertPizzaProductIntoDB();

        }

        private void InitializeObjects()
        {

            _pizzaMapper = new Mapper(PizzaMapper.NewPizzaDTOToPizzaProductMap());

        }
        private void MapNewPizzaDTOToPizzaProduct()
        {
            _pizza = _pizzaMapper!.Map<Product>(_newPizzaDTO);

            _pizza.ProductId = GetLatestPizzaProductId();
            _pizza.CategoryId = _newPizzaDTO!.CategoryId;
            _pizza.SupplierId = _newPizzaDTO!.SupplierId!;
            _pizza.QuantityPerUnit = GetQuantityPerUnitString(
                _newPizzaDTO!.QuantityPerUnit
            );
            _pizza.ProductImage = ImageUtils.ConvertImageStringToByteArray(
                _newPizzaDTO.ProductImage!
                );
        }

        private void InsertPizzaProductIntoDB()
        {
            _unitOfWork!.ProductRepository!.Insert(_pizza!);
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

    }
}
