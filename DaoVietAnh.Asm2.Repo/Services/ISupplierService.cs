using DaoVietAnh.Asm2.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services
{
    public interface ISupplierService
    {
        List<SupplierDTO> GetSuppliers();
    }
}
