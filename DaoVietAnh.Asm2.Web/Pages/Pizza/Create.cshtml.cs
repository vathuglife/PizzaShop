using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        public List<CategoryDTO>? Categories { get; set; }
        public List<SupplierDTO>? Suppliers { get; set; }
        private NewPizzaDTO? _newPizzaDTO { get; set; }                
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
        public IActionResult OnPostCreatePizza([FromBody] NewPizzaDTO newPizzaDTO)        
        {
            _newPizzaDTO = newPizzaDTO;
            _pizzaService!.Insert(_newPizzaDTO);
            return RedirectToPage("/Pizza/Create");

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
