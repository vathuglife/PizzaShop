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
    public static class SupplierMapper
    {
        public static MapperConfiguration SupplierToSupplierDTOMap()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<Supplier, SupplierDTO>()
                .ForMember(destination => destination.SupplierId,
                        option
                            => option.MapFrom(source => source.SupplierId))
                .ForMember(destination => destination.CompanyName,
                        option
                            => option.MapFrom(source => source.CompanyName))
            );
        }
    }
}
