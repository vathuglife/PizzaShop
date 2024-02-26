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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class GetUpdatePizzaByIdService
    {
        private UnitOfWork? _unitOfWork;
        private UpdatePizzaDTO? _updatePizzaDTO;
        private Product? _pizza;
        private Mapper? _mapper;
        private int _id;
        public GetUpdatePizzaByIdService()
        {
            InitializeObjects();
        }
        public PizzaServiceResponse Get(int id)
        {
            _id = id;
            GetPizzaFromDbById();
            MapPizzaProductToUpdatePizzaDTO();
            return GetSuccessfulPizzaRetrievalResult();
        }
        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _mapper = new Mapper(PizzaMapper.PizzaProductToUpdatePizzaDTO());
        }
        private void GetPizzaFromDbById()
        {
            _pizza = _unitOfWork!.ProductRepository!.GetByID(_id);
        }
        private void MapPizzaProductToUpdatePizzaDTO()
        {
            Category category = _unitOfWork?.CategoryRepository!.GetByID(_pizza!.CategoryId!)!;
            _updatePizzaDTO = _mapper!.Map<UpdatePizzaDTO>(_pizza);
            _updatePizzaDTO.QuantityPerUnit = GetQuantityPerUnitInt(_pizza!.QuantityPerUnit!);
            //_updatePizzaDTO.Description = category.Description;
            _updatePizzaDTO.ProductImage = ImageUtils.GetBase64ImageFromByteArray(_pizza!.ProductImage!);
        }
        private int GetQuantityPerUnitInt(string quantityPerUnit)
        {
            return Convert.ToInt32(Regex.Match(quantityPerUnit, @"\d+").Value);
        }
        private PizzaServiceResponse GetSuccessfulPizzaRetrievalResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "",
                ReturnData = _updatePizzaDTO
            };
        }
    }
}
