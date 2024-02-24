namespace DaoVietAnh.Asm2.Repo.DTO
{
    public class NewPizzaDTO
    {
        public string? Name { get; set; }
        public int SupplierId{ get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? ProductImage { get; set; }
    }
}
