using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.DTO
{
    public class UpdatePizzaDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SupplierId { get; set; }
        //public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? ProductImage { get; set; }
    }
}
