using AutoMapper;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Mappers
{
    public static class PizzaMapper
    {
        public static MapperConfiguration NewPizzaDTOToPizzaProductMap()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<NewPizzaDTO, Product>()
                .ForMember(destination => destination.ProductName,
                        option => option.MapFrom(source => source.Name))
                .ForMember(destination => destination.SupplierId,
                        option => option.MapFrom(source => source.SupplierId))
                .ForMember(destination => destination.CategoryId,
                        option => option.MapFrom(source => source.CategoryId))
                .ForMember(destination => destination.QuantityPerUnit,
                        option => option.MapFrom(source => source.QuantityPerUnit))
                .ForMember(destination => destination.UnitPrice,
                        option => option.MapFrom(source => source.UnitPrice))
                .ForMember(destination => destination.ProductImage, option => option.Ignore())
            );
        }
        public static MapperConfiguration PizzaProductToPizzaDTO()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<Product, PizzaDTO>()
                .ForMember(destination => destination.Id,
                        option => option.MapFrom(source => source.ProductId))
                
                .ForMember(destination => destination.Name,
                        option => option.MapFrom(source => source.ProductName))
                
                .ForMember(destination => destination.Category,option => option.Ignore())
                
                .ForMember(destination => destination.Description,
                        option => option.Ignore())
                
                .ForMember(destination => destination.Price,
                        option => option.MapFrom(source => source.UnitPrice))
                
                .ForMember(destination => destination.Image, option => option.Ignore())
            );
        }        
    }
}
