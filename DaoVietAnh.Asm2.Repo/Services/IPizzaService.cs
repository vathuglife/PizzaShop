﻿using DaoVietAnh.Asm2.Repo.DTO;
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
        Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingRequest pageConfig);
        Task<PizzaServiceResponse> GetPizzasBy(GetPizzasByRequest getPizzaByRequest);
        PizzaServiceResponse GetPizzaById(int id);
        PizzaServiceResponse GetUpdatePizzaById(int id);
        PizzaServiceResponse Insert(NewPizzaDTO newPizzaDTO);
        PizzaServiceResponse Update(UpdatePizzaDTO updatePizzaDTO);
        PizzaServiceResponse Delete(int id);

    }
}
