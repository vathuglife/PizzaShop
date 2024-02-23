using DaoVietAnh.Asm2.Repo.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Entities.Results
{
    public class AccountServiceResult
    {
        public AccountServiceEnum Result { get; set; }
        public string? Message { get; set; }        
        public Object? ReturnData { get; set; }
    }
}
