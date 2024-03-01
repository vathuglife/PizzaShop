using DaoVietAnh.Asm2.Repo.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Payload.Request
{
    public class GetPizzasByRequest
    {
        public string? Value { get; set; }
        public GetPizzasByEnum? Option { get; set; }
    }
}
