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
    public static class AccountMapper
    {
        public static MapperConfiguration RegisterCredentialsToAccountMap()
        {
            return new MapperConfiguration(config =>
                config.CreateMap<RegisterCredentialsDTO, Account>()
                .ForMember(destination => destination.FullName,
                        option
                            => option.MapFrom(source => source.Name))
                .ForMember(destination => destination.UserName,
                        option
                            => option.MapFrom(source => source.Username))
                    .ForMember(destination => destination.Password,
                        option
                            => option.MapFrom(source => source.Password))
            );
        }
    }
}
