using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services
{
    public interface IPizzaService
    {
        Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingParameters pageConfig);
        PizzaServiceResponse GetPizzaById(int id);    
        PizzaServiceResponse Insert(NewPizzaDTO newPizzaDTO);

    }
}
