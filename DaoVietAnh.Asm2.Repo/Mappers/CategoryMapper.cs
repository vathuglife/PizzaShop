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
    public static class CategoryMapper
    {
        public static MapperConfiguration CategoryToCategoryDTOMap()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<Category, CategoryDTO>()
                .ForMember(destination => destination.CategoryId,
                        option
                            => option.MapFrom(source => source.CategoryId))
                .ForMember(destination => destination.CategoryName,
                        option
                            => option.MapFrom(source => source.CategoryName))
                .ForMember(destination => destination.Description,
                    option
                        => option.MapFrom(source => source.Description))
            );
        }
        public static MapperConfiguration NewPizzaDTOToCategoryMap()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<NewPizzaDTO, Category>()
                .ForMember(destination => destination.CategoryName,
                        option => option.MapFrom(source => source.Name))
                .ForMember(destination => destination.Description,
                        option => option.MapFrom(source => source.SupplierId))
                .ForMember(destination => destination.CategoryId, option => option.Ignore())
            );
        }
    }
}
