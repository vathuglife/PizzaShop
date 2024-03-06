using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services
{
    public interface IOrderService
    {
        OrderServiceResponse CreateOrder(CreateOrderRequest request);
    }
}
