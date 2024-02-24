using DaoVietAnh.Asm2.Repo.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Payload.Response
{
    public class PizzaServiceResponse
    {
        public PizzaServiceEnum Result { get; set; }
        public string? Message { get; set; }
        public object? ReturnData { get; set; }
    }
}
