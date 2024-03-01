using AutoMapper;
using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using DaoVietAnh.Asm2.Repo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class GetPizzaByIdService
    {
        private IUnitOfWork? _unitOfWork;
        private PizzaDTO? _pizzaDTO;
        private Product? _pizza;
        private Mapper? _mapper;
        private int _id;
        public GetPizzaByIdService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public PizzaServiceResponse GetById(int id)
        {
            _id = id;
            GetPizzaFromDbById();
            MapPizzaProductToPizzaDTO();
            return GetSuccessfulPizzaRetrievalResult();
        }
        private void GetPizzaFromDbById()
        {
            _pizza = _unitOfWork!.ProductRepository!.GetByID(_id);
        }
        private void MapPizzaProductToPizzaDTO()
        {
            Category category = _unitOfWork?.CategoryRepository!.GetByID(_pizza!.CategoryId!)!;
            _pizzaDTO = _mapper!.Map<PizzaDTO>(_pizza);
            _pizzaDTO.Category = category.CategoryName;
            _pizzaDTO.Description = category.Description;
            _pizzaDTO.Image = ImageUtils.GetBase64ImageFromByteArray(_pizza!.ProductImage!);
        }
        private void InitializeObjects()
        {
            
            _mapper = new Mapper(PizzaMapper.PizzaProductToPizzaDTO());
        }
        private PizzaServiceResponse GetSuccessfulPizzaRetrievalResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "",
                ReturnData = _pizzaDTO
            };
        }
    }
}
