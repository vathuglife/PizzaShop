using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        public List<CategoryDTO>? Categories { get; set; }
        public List<SupplierDTO>? Suppliers { get; set; }
        public UpdatePizzaDTO? Pizza { get; set; }
        private ICategoryService? _categoryService;
        private ISupplierService? _supplierService;
        private IPizzaService? _pizzaService;

        public UpdateModel(ICategoryService categoryService,
            ISupplierService supplierService, IPizzaService? pizzaService)
        {
            _categoryService = categoryService;
            _supplierService = supplierService;
            _pizzaService = pizzaService;
        }
        public void OnGet(int pizzaId)
        {
            GetCategories();
            GetSuppliers();
            GetUpdatePizzaById(pizzaId);
        }
        public void OnPostUpdatePizza()
        {
            var result = _pizzaService!.Update(Pizza!);
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
        private void GetUpdatePizzaById(int pizzaId)
        {
            var result = _pizzaService!.GetUpdatePizzaById(pizzaId);
            Pizza = (UpdatePizzaDTO)result.ReturnData!;
        }
    }
}
