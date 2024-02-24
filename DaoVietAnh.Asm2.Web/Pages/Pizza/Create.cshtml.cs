using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        public List<CategoryDTO>? Categories { get; set; }
        public List<SupplierDTO>? Suppliers { get; set; }
        public NewPizzaDTO? Pizza { get; set; }                
        private ICategoryService? _categoryService;
        private ISupplierService? _supplierService;
        private IPizzaService? _pizzaService;

        public CreateModel(ICategoryService categoryService,
            ISupplierService supplierService, IPizzaService? pizzaService)
        {
            _categoryService = categoryService;
            _supplierService = supplierService;
            _pizzaService = pizzaService;   
        }
        public void OnGet()
        {
            GetCategories();
            GetSuppliers();
        }
        public void OnPost()        
        {
            _pizzaService!.Insert(Pizza!);
        }
       
        private void GetCategories()
        {
            var categories = _categoryService!.GetCategories().ReturnData;
            Categories = (List<CategoryDTO>)categories!;
        }
        private void GetSuppliers()
        {
            Suppliers = _supplierService!.GetSuppliers();
        }
    }
}
